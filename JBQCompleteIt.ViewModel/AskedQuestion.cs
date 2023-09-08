using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using JBQCompleteIt.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace JBQCompleteIt.ViewModel
{
    /// <summary>
    /// An asked question in the game
    /// </summary>
    public class AskedQuestion : ObservableObject
    {
        private int _number;
        /// <summary>
        /// Bible Fact-Pak™ question number
        /// </summary>
        public int Number
        {
            get => _number;
            set => SetProperty(ref _number, value);
        }

        private QuestionTypeEnum _type;
        /// <summary>
        /// Question type
        /// </summary>
        public QuestionTypeEnum Type
        {
            get => _type;
            set
            {
                SetProperty(ref _type, value);
                OnPropertyChanged(nameof(IsMultipleChoiceType));
                OnPropertyChanged(nameof(IsQuotationQuestionType));
            }
        }

        public bool IsMultipleChoiceType
        {
            get => _type == QuestionTypeEnum.MultipleChoice;
        }

        public bool IsQuotationQuestionType
        {
            get => _type == QuestionTypeEnum.QuotationQuestion;
        }

        private string _question;
        /// <summary>
        /// Question text
        /// </summary>
        public string Question
        {
            get => _question;
            set => SetProperty(ref _question, value);
        }

        private ObservableCollection<AnswerSegment> _possibleAnswerSegments;
        /// <summary>
        /// Answer broken down into segments. Not all segments are part of the correct answer
        /// </summary>
        /// <remarks>Segments are randomized before this property is set</remarks>
        public ObservableCollection<AnswerSegment> PossibleAnswerSegments
        {
            get => _possibleAnswerSegments;
            set
            {
                if(_possibleAnswerSegments != null)
                {
                    _possibleAnswerSegments.CollectionChanged -= Answer_CollectionChanged;
                    RemoveCollectionItems(_possibleAnswerSegments);
                }
                SetProperty(ref _possibleAnswerSegments, value);
                CorrectAnswerSegmentCount = _possibleAnswerSegments.Count(x => x.IsPartOfAnswer);
                if (_possibleAnswerSegments != null)
                {
                    _possibleAnswerSegments.CollectionChanged += Answer_CollectionChanged;
                    AddCollectionItems(_possibleAnswerSegments);
                }
                RebuildGivenAnswer();
            }
        }

        private int _correctAnswerSegmentCount;
        /// <summary>
        /// The number of answer segments that are part of the correct answer
        /// </summary>
        public int CorrectAnswerSegmentCount
        {
            get => _correctAnswerSegmentCount;
            private set => SetProperty(ref _correctAnswerSegmentCount, value);
        }

        private void Answer_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            RemoveCollectionItems((IEnumerable<AnswerSegment>)e.OldItems);

            AddCollectionItems((IEnumerable<AnswerSegment>)e.NewItems);

            if (e.OldItems != null || e.NewItems != null)
            {
                RebuildGivenAnswer();
            }
        }

        private void RemoveCollectionItems(IEnumerable<AnswerSegment> coll)
        {
            foreach (var item in coll)
            {
                var observableItem = item as ObservableObject;
                if (observableItem != null)
                {
                    observableItem.PropertyChanged -= ObservableItem_PropertyChanged;
                }
            }
        }

        private void AddCollectionItems(IEnumerable<AnswerSegment> coll)
        {
            foreach (var item in coll)
            {
                var observableItem = item as ObservableObject;
                if (observableItem != null)
                {
                    observableItem.PropertyChanged += ObservableItem_PropertyChanged;
                }
            }
        }

        private void ObservableItem_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(AnswerSegment.GivenIndex))
            {
                RebuildGivenAnswer();
            }
        }

        private ObservableCollection<AnswerSegment> _givenAnswer = new ObservableCollection<AnswerSegment>();
        /// <summary>
        /// Answer broken down into elements
        /// </summary>
        public ObservableCollection<AnswerSegment> GivenAnswer
        {
            get => _givenAnswer;
        }

        private string _passage;
        /// <summary>
        /// Passage reference for the question
        /// </summary>
        public string Passage
        {
            get => _passage;
            set
            {
                SetProperty(ref _passage, value);
                OnPropertyChanged(nameof(IsPassagePresent));
            }
        }

        public bool IsPassagePresent
        {
            get => Passage != null;
        }

        public bool IsCompleteAnswerGiven
        {
            get => GivenAnswer.Count(x => !x.IsBlank) == PossibleAnswerSegments.Count(x => x.IsPartOfAnswer);
        }

        public bool IsCorrectAnswerGiven
        {
            get => GivenAnswer.Where(x => !x.IsBlank).All(x => x.CorrectIndexes != null && x.CorrectIndexes.Any(y => y == x.GivenIndex));
        }
        
        public List<AnswerSegment> GetWrongElements()
        {
            return PossibleAnswerSegments.Where(x => x.IsWrong).ToList();
        }

        public int GetFirstAvailableGivenIndex()
        {
            var retVal = 0;

            foreach (var x in GivenAnswer)
            {
                if (x.IsBlank)
                {
                    break;
                }
                retVal++;
            }

            return retVal;
        }

        public AnswerSegment GetNextCorrectAnswerElement()
        {
            return PossibleAnswerSegments
                .Where(x => x.IsPartOfAnswer)
                .OrderBy(x => x.Index)
                .FirstOrDefault(x => x.IsOrderNotGiven);
        }

        /// <summary>
        /// Rebuild the given answer anytime something changes with the answer elements
        /// </summary>
        private void RebuildGivenAnswer([CallerMemberName] string memberName = "")
        {
            Debug.WriteLine($"{nameof(AskedQuestion)} - {memberName} - Rebuilding given answer");

            GivenAnswer.Clear();

            for (int i = 0; i < CorrectAnswerSegmentCount; i++)
            {
                var element = PossibleAnswerSegments.SingleOrDefault(x => x.GivenIndex == i);

                element ??= new AnswerSegment();

                GivenAnswer.Add(element);
            }

            OnPropertyChanged(nameof(IsCompleteAnswerGiven));
            OnPropertyChanged(nameof(IsCorrectAnswerGiven));
        }

        public void ResetWrongAnswers()
        {
            foreach (var elements in GetWrongElements())
            {
                elements.GivenIndex = null;
            }
        }
    }
}
