using CommunityToolkit.Mvvm.Input;
using JBQCompleteIt.Repository;
using JBQCompleteIt.ViewModel.Extensions;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;

namespace JBQCompleteIt.ViewModel.Providers
{
    /// <summary>
    /// Provider for JBQ questions to ask
    /// </summary>
    public class QuestionProvider
    {
        static private readonly Random _random = new Random();

        private readonly Dictionary<int, int> _timesAsked = new Dictionary<int, int>();

        private readonly IQuestionRepository _repository;

        private readonly int? _startQuestionNumber, _endQuestionNumber;

        private int _iterQuestionNum;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="repository">An instance of the question repository interface</param>
        /// <param name="startQuestionNumber">Starting question number. Null if no limit</param>
        /// <param name="endQuestionNumber">Ending question number. Null if no limit</param>
        /// <exception cref="ArgumentNullException">An invalid constructor argument was given, see exeception information</exception>
        /// <exception cref="ArgumentOutOfRangeException">One of the constructor arguments has an invalid value</exception>
        /// <remarks>Both start and end question number must be provided or both must be null.</remarks>
        public QuestionProvider(IQuestionRepository repository, int? startQuestionNumber, int? endQuestionNumber)
        {
            if (repository == null)
            {
                throw new ArgumentNullException(nameof(repository), "A repository instance must be provided");
            }

            _repository = repository;
            _startQuestionNumber = startQuestionNumber;
            _endQuestionNumber = endQuestionNumber;

            _iterQuestionNum = _repository.GetMinNumber();

            if (_startQuestionNumber.HasValue && _endQuestionNumber.HasValue && !InIterateQuestionsMode())
            {
                for (int i = _startQuestionNumber.Value; i <= _endQuestionNumber.Value; i++)
                {
                    _timesAsked.Add(i, 0);
                }
            }
            else
            {
                int minQuestionNumber = _repository.GetMinNumber();
                int maxQuestionNumber = _repository.GetMaxNumber();
                int count = maxQuestionNumber - minQuestionNumber;

                for (int i = 1; i <= count; i++)
                {
                    _timesAsked.Add(i + minQuestionNumber, 0);
                }
            }
        }

        public bool InIterateQuestionsMode()
        {
            return _startQuestionNumber == _repository.GetMaxNumber() &&
                _endQuestionNumber == _repository.GetMaxNumber();
        }

        /// <summary>
        /// Gets the next question
        /// </summary>
        /// <param name="difficulty">Game difficulty</param>
        /// <returns>A question with a correct answer and one or more wrong answers</returns>
        /// <exception cref="InvalidOperationException">Question was not found in question number tracking</exception>
        public AskedQuestion GetNextQuestion(DifficultyEnum difficulty)
        {
            var minTimesAsked = _timesAsked.Min(x => x.Value);

            var nextNumber = GetNextQuestionNumber();

            while (1 == 1)
            {
                int timesAsked = 0;
                if (_timesAsked.TryGetValue(nextNumber, out timesAsked))
                {
                    if (timesAsked <= minTimesAsked)
                    {
                        _timesAsked[nextNumber] = timesAsked + 1;
                        break;
                    }
                    else
                    {
                        nextNumber = GetNextQuestionNumber();
                    }
                }
                else
                {
                    throw new InvalidOperationException("Question number not found in asked count tracking");
                }
            }

            var question = _repository.GetByNumber(nextNumber);

            var retVal = new AskedQuestion
            {
                Number = question.Number,
                Question = question.Question,
                Passage = question.Passage,
                Type = question.Type
            };

            var answerElements = new List<AnswerSegment>();
            int index = 0;
            foreach (var element in question.Answer)
            {
                var answerElement = new AnswerSegment
                {
                    Text = element,
                    Index = index,
                    CorrectIndexes = new List<int> { index }
                };

                answerElement.Clicked = new AsyncRelayCommand(async () =>
                {
                    if (answerElement.GivenIndex.HasValue)
                    {
                        answerElement.GivenIndex = null;
                    }
                    else
                    {
                        if (question.Type == QuestionTypeEnum.MultipleChoice)
                        {
                            var found = retVal.PossibleAnswerSegments.FirstOrDefault(x => x.GivenIndex != null);
                            if (found != null)
                            {
                                found.GivenIndex = null;
                            }
                        }

                        answerElement.GivenIndex = retVal.GetFirstAvailableGivenIndex();
                    }
                });

                answerElements.Add(answerElement);

                index++;
            }

            // Add alternative correct indexes for case where the same word is repeated in the answer and can be interchanged
            foreach(var element in answerElements)
            {
                var altCorrectElements = answerElements.Where(x => x.Index != element.Index && x.Text == element.Text);

                element.CorrectIndexes.AddRange(altCorrectElements.Select(x => x.Index.Value));
            }

            if (question.WrongAnswers != null)
            {
                var trimmedWrongAnswers = question.WrongAnswers.Shuffle().Take(3);

                foreach (var element in trimmedWrongAnswers)
                {
                    var answerElement = new AnswerSegment
                    {
                        Text = element,
                        CorrectIndexes = null
                    };

                    answerElement.Clicked = new AsyncRelayCommand(async () =>
                    {
                        if (answerElement.GivenIndex.HasValue)
                        {
                            answerElement.GivenIndex = null;
                        }
                        else
                        {
                            if (question.Type == QuestionTypeEnum.MultipleChoice)
                            {
                                var found = retVal.PossibleAnswerSegments.FirstOrDefault(x => x.GivenIndex != null);
                                if (found != null)
                                {
                                    found.GivenIndex = null;
                                }
                            }

                            var maxGivenIndex = retVal.PossibleAnswerSegments.MaxBy(x => x.GivenIndex).GivenIndex;
                            if (maxGivenIndex.HasValue)
                            {
                                answerElement.GivenIndex = maxGivenIndex + 1;
                            }
                            else
                            {
                                answerElement.GivenIndex = 0;
                            }
                        }
                    });

                    answerElements.Add(answerElement);
                }
            }
            answerElements.Shuffle();

            retVal.PossibleAnswerSegments = new ObservableCollection<AnswerSegment>(answerElements);

            if (retVal.Type == QuestionTypeEnum.Jumble || retVal.Type == QuestionTypeEnum.QuotationQuestion)
            {
                PreAnswerJumbleSegments(retVal, difficulty);
            }

            return retVal;
        }
        
        private int GetNextQuestionNumber()
        {
            if (InIterateQuestionsMode())
            {
                // Special mode to iterate through all questions

                if (_iterQuestionNum == _repository.GetMaxNumber())
                {
                    _iterQuestionNum = _repository.GetMinNumber();
                }

                _iterQuestionNum++;

                return _iterQuestionNum;
            }
            else if (_startQuestionNumber.HasValue && _endQuestionNumber.HasValue)
            {
                return _random.Next(_startQuestionNumber.Value, _endQuestionNumber.Value + 1);
            }
            else
            {
                int min = _repository.GetMinNumber();
                int max = _repository.GetMaxNumber();

                return _random.Next(min, max + 1);
            }
        }

        static private void PreAnswerJumbleSegments(AskedQuestion question, DifficultyEnum difficulty)
        {
            Debug.Assert(question.Type == QuestionTypeEnum.Jumble || question.Type == QuestionTypeEnum.QuotationQuestion);

            int segmentCount = question.CorrectAnswerSegmentCount;

            int segmentCountToPreAnswer = 0;
            if(difficulty == DifficultyEnum.Easy)
            {
                segmentCountToPreAnswer = (int)Math.Floor(segmentCount * .75);
            }
            else if(difficulty == DifficultyEnum.Normal)
            {
                segmentCountToPreAnswer = (int)Math.Floor(segmentCount * .5);
            }

            for (int i = 0; i < segmentCountToPreAnswer; i++)
            {
                // Random pick a segment that has not be answered yet
                var segmentToAnswer = question.PossibleAnswerSegments.ElementAt(_random.Next(segmentCount));
                while(segmentToAnswer.IsOrderGiven)
                {
                    segmentToAnswer = question.PossibleAnswerSegments.ElementAt(_random.Next(segmentCount));
                }

                segmentToAnswer.GivenIndex = segmentToAnswer.Index;
                segmentToAnswer.PreAnswered = true;
            }
        }
    }
}
