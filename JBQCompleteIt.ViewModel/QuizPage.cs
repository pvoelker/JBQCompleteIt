using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using JBQCompleteIt.Repository;
using JBQCompleteIt.ViewModel.Providers;
using System;

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

        private static string _defaultSuccessLottie = "animation_lmiimwnq.json";

        private Random _random = new Random();

        private System.Timers.Timer _hintTimer = new System.Timers.Timer();

        private QuestionProvider _questionProvider = null;

        static QuizPage()
        {
            var minDim = Math.Min(DeviceDisplay.Current.MainDisplayInfo.Height, DeviceDisplay.Current.MainDisplayInfo.Width);
            var minDimDensityRatio = minDim / DeviceDisplay.Current.MainDisplayInfo.Density;

            _isSmallScreen = minDimDensityRatio < 600;
        }

        public QuizPage()
        {
            SubmitAnswer = new RelayCommand(() =>
            {
                if (CurrentQuestion.IsCorrectAnswerGiven)
                {
                    // Reset hint timer
                    if (EnableHints == true)
                    {
                        _hintTimer.Stop();
                        _hintTimer.Start();
                    }

                    CorrectAnswers = CorrectAnswers + 1;

                    if (IsGoodRole(.3))
                    {
                        int index = _random.Next(_successLotties.Count);
                        LottieRepeatCount = 1;
                        LottieImageFile = _successLotties[index];
                    }
                    else
                    {
                        LottieRepeatCount = 0;
                        LottieImageFile = _defaultSuccessLottie;
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

                CurrentQuestion = _questionProvider.GetNextQuestion(Difficulty);
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

            CurrentQuestion = _questionProvider.GetNextQuestion(Difficulty);

            _hintTimer.Elapsed += _timer_Elapsed;

            _hintTimer.Interval = 3000;
            _hintTimer.AutoReset = false;

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

                _hintTimer.Start();
            }
        }

        private static bool _isSmallScreen = false;
        public bool IsSmallScreen
        {
            get => _isSmallScreen;
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

        private int _lottieRepeatCount = 0;
        /// <summary>
        /// This is how many additional times to run the Lottie animation.  The animation will always play once
        /// </summary>
        public int LottieRepeatCount
        {
            get => _lottieRepeatCount;
            set => SetProperty(ref _lottieRepeatCount, value);
        }

        private DifficultyEnum _difficulty;
        public DifficultyEnum Difficulty
        {
            get => _difficulty;
            set => SetProperty(ref _difficulty, value);
        }

        private bool _enableHints = false;
        public bool EnableHints
        {
            get => _enableHints;
            set
            {
                SetProperty(ref _enableHints, value);
                OnPropertyChanged(nameof(AreHintsNotEnabled));
            }
        }
        public bool AreHintsNotEnabled
        {
            get => !_enableHints;
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