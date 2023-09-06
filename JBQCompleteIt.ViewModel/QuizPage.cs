using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using JBQCompleteIt.Repository;
using JBQCompleteIt.ViewModel.Providers;
using System.Diagnostics;

namespace JBQCompleteIt.ViewModel
{
    public class QuizPage : ObservableObject
    {
        private static readonly List<string> _successLotties = new List<string>()
        {
            "animation_llk4smhk.json",
            "animation_llk4thp5.json",
            "animation_llk4yanu.json",
            "animation_llk4zljq.json",
            "animation_llk528hr.json"
        };

        private Random _random = new Random();

        private System.Timers.Timer _hintTimer = new System.Timers.Timer();

        private QuestionProvider _questionProvider = null;

        public QuizPage()
        {
            SubmitAnswer = new RelayCommand(() =>
            {
                if (CurrentQuestion.IsCorrectAnswerGiven)
                {
                    // Reset hint timer
                    if (_hintTimer.Enabled)
                    {
                        _hintTimer.Stop();
                        _hintTimer.Start();
                    }

                    CorrectAnswers = CorrectAnswers + 1;

                    if (IsGoodRole(.3))
                    {
                        int index = _random.Next(_successLotties.Count);
                        LottieImageFile = _successLotties[index];
                    }
                    else
                    {
                        CurrentQuestion = _questionProvider.GetNextQuestion();
                    }
                }
                else
                {
                    CurrentQuestion.ResetWrongAnswers();

                    WrongAnswers = WrongAnswers + 1;
                }
            });

            CancelAnimation = new RelayCommand(() =>
            {
                LottieImageFile = null;

                CurrentQuestion = _questionProvider.GetNextQuestion();
            });

            AnimationComplete = new RelayCommand(() =>
            {
                CancelAnimation.Execute(this);
            });
        }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task InitializeAsync()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            _questionProvider = new QuestionProvider(new QuestionsRepository(), null, null);

            CurrentQuestion = _questionProvider.GetNextQuestion();

            _hintTimer.Elapsed += _timer_Elapsed;

            _hintTimer.Interval = 10000;

            _hintTimer.Enabled = EnableHints;
            if (EnableHints == true)
            {
                _hintTimer.Start();
            }
        }

        private async void _timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if(CurrentQuestion != null)
            {
                var nextCorrectAnswerElement = CurrentQuestion.GetNextCorrectAnswerElement();

                if (nextCorrectAnswerElement != null)
                {
                    if(nextCorrectAnswerElement.ShowHint != null)
                    {
                        await nextCorrectAnswerElement.ShowHint.ExecuteAsync(this);
                    }
                }
            }
        }

        private AskedQuestion _currentQuestion = null;
        public AskedQuestion CurrentQuestion
        {
            get => _currentQuestion;
            private set => SetProperty(ref _currentQuestion, value);
        }

        private string _lottieImageFile = null;
        public string LottieImageFile
        {
            get => _lottieImageFile;
            set => SetProperty(ref _lottieImageFile, value);
        }

        private bool _enableHints = false;
        public bool EnableHints
        {
            get => _enableHints;
            set => SetProperty(ref _enableHints, value);
        }

        private int? _startQuestionNumber = null;
        public int? StartQuestionNumber
        {
            get => _startQuestionNumber;
            set => SetProperty(ref _startQuestionNumber, value);
        }

        private int? _endQuestionNumber = null;
        public int? EndQuestionNumber
        {
            get => _endQuestionNumber;
            set => SetProperty(ref _endQuestionNumber, value);
        }

        private int _correctAnswers = 0;
        public int CorrectAnswers
        {
            get => _correctAnswers;
            private set => SetProperty(ref _correctAnswers, value);
        }

        private int _wrongAnswers = 0;
        public int WrongAnswers
        {
            get => _wrongAnswers;
            private set => SetProperty(ref _wrongAnswers, value);
        }

        #region Commands

        /// <summary>
        /// Command for when the user submits their answer
        /// </summary>
        public IRelayCommand SubmitAnswer { get; private set; }

        public IRelayCommand CancelAnimation { get; private set; }

        public IRelayCommand AnimationComplete { get; private set; }

        #endregion

        private bool IsGoodRole(double chance)
        {
            return _random.NextDouble() < chance;
        }
    }
}