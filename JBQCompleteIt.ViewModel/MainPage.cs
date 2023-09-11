using CommunityToolkit.Mvvm.ComponentModel;
using JBQCompleteIt.Repository;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace JBQCompleteIt.ViewModel
{
    // All the code in this file is included in all platforms.
    public class MainPage : ObservableValidator
    {
        public MainPage()
        {
            var repository = new QuestionsRepository();

            MinQuestionNumber = repository.GetMinNumber();
            MaxQuestionNumber = repository.GetMaxNumber();

            StartQuestionNumberStr = Preferences.Default.Get<string>(PreferenceKeys.StartQuestionRange, null);
            EndQuestionNumberStr = Preferences.Default.Get<string>(PreferenceKeys.EndQuestionRange, null);
            LearningMode = Preferences.Default.Get<bool>(PreferenceKeys.LearningMode, false);
            if (Enum.TryParse<DifficultyEnum>(Preferences.Default.Get<string>(PreferenceKeys.Difficulty, null), out var diffEnum))
            {
                Difficulty = diffEnum;
            }

            var assembly = Assembly.GetEntryAssembly();

            if (assembly != null)
            {
                Version = assembly.GetName().Version;
                object[] attribs = assembly.GetCustomAttributes(typeof(AssemblyCopyrightAttribute), true);
                if (attribs.Length > 0)
                {
                    Copyright = ((AssemblyCopyrightAttribute)attribs[0]).Copyright;
                }
                else
                {
                    Copyright = "ERROR: Unable to get copyright";
                }
            }
            else
            {
                Version = AppInfo.Current.Version;
                Copyright = null;
            }
        }

        #region Commands

        #endregion

        public bool IsVersionInfoPresent
        {
            get => Version != null;
        }

        private Version _version;
        public Version Version
        {
            get => _version;
            private set
            {
                SetProperty(ref _version, value);
                OnPropertyChanged(nameof(IsVersionInfoPresent));
            }
        }

        private string _copyright;
        public string Copyright
        {
            get => _copyright;
            private set => SetProperty(ref _copyright, value);
        }

        public IReadOnlyList<string> AllDifficulties { get; } = Enum.GetNames(typeof(DifficultyEnum));

        private DifficultyEnum _difficulty = DifficultyEnum.Easy;
        public DifficultyEnum Difficulty
        {
            get => _difficulty;
            set
            {
                Preferences.Default.Set(PreferenceKeys.Difficulty, Enum.GetName(typeof(DifficultyEnum), value));
                SetProperty(ref _difficulty, value);
            }
        }

        private bool _learningMode = false;
        public bool LearningMode
        {
            get => _learningMode;
            set
            {
                Preferences.Default.Set(PreferenceKeys.LearningMode, value);
                SetProperty(ref _learningMode, value);
            }
        }

        private int _minQuestionNumber;
        public int MinQuestionNumber
        {
            get => _minQuestionNumber;
            private set => SetProperty(ref _minQuestionNumber, value);
        }

        private int _maxQuestionNumber;
        public int MaxQuestionNumber
        {
            get => _maxQuestionNumber;
            private set => SetProperty(ref _maxQuestionNumber, value);
        }

        private string _startQuestionNumber = null;
        [CustomValidation(typeof(MainPage), nameof(ValidateQuestionRange))]
        public string StartQuestionNumberStr
        {
            get => _startQuestionNumber;
            set
            {
                Preferences.Default.Set(PreferenceKeys.StartQuestionRange, value);
                SetProperty(ref _startQuestionNumber, value, true);
                ValidateProperty(EndQuestionNumberStr, nameof(EndQuestionNumberStr));
                OnPropertyChanged(nameof(StartQuestionNumber));
            }
        }
        public int? StartQuestionNumber
        {
            get
            {
                if (int.TryParse(_startQuestionNumber, out int intVal))
                {
                    return intVal;
                }
                else
                {
                    return null;
                }
            }
        }

        private string _endQuestionNumber = null;
        [CustomValidation(typeof(MainPage), nameof(ValidateQuestionRange))]
        public string EndQuestionNumberStr
        {
            get => _endQuestionNumber;
            set
            {
                Preferences.Default.Set(PreferenceKeys.EndQuestionRange, value);
                SetProperty(ref _endQuestionNumber, value, true);
                ValidateProperty(StartQuestionNumberStr, nameof(StartQuestionNumberStr));
                OnPropertyChanged(nameof(EndQuestionNumber));
            }
        }
        public int? EndQuestionNumber
        {
            get
            {
                if (int.TryParse(_endQuestionNumber, out int intVal))
                {
                    return intVal;
                }
                else
                {
                    return null;
                }
            }
        }

        public static ValidationResult ValidateQuestionRange(string name, ValidationContext context)
        {
            var instance = (MainPage)context.ObjectInstance;

            if (instance.StartQuestionNumber.HasValue && (instance.StartQuestionNumber < instance.MinQuestionNumber))
            {
                return new("Start question number must be greater than or equal to the first question number");
            }
            else if (instance.EndQuestionNumber.HasValue && (instance.EndQuestionNumber < instance.MinQuestionNumber))
            {
                return new("End question number must be greater than or equal to the first question number");
            }
            else if (instance.StartQuestionNumber.HasValue && (instance.StartQuestionNumber > instance.MaxQuestionNumber))
            {
                return new($"Start question number must be equal to or less than {instance.MaxQuestionNumber}. This game only uses 10 point questions from the Bible Fact-Pak™.");
            }
            else if (instance.EndQuestionNumber.HasValue && (instance.EndQuestionNumber > instance.MaxQuestionNumber))
            {
                return new($"End question number must be equal to or less than {instance.MaxQuestionNumber}. This game only uses 10 point questions from the Bible Fact-Pak™.");
            }
            else if ((instance.StartQuestionNumber.HasValue && instance.StartQuestionNumber.Value != 0)
                ^ (instance.EndQuestionNumber.HasValue && instance.EndQuestionNumber.Value != 0))
            {
                return new($"If specifying a question range, both 'start' and 'end' must be provided");
            }
            else if(instance.StartQuestionNumber >= instance.EndQuestionNumber)
            {
                if (instance.StartQuestionNumber != instance.MaxQuestionNumber &&
                    instance.EndQuestionNumber != instance.MaxQuestionNumber)
                {
                    return new("Start question number must be less than the end question number");
                }
            }
            else if((instance.EndQuestionNumber - instance.StartQuestionNumber + 1) < 10)
            {
                if (instance.StartQuestionNumber != instance.MaxQuestionNumber &&
                    instance.EndQuestionNumber != instance.MaxQuestionNumber)
                {
                    return new("Range of questions must be equal to or greater than 10");

                }
            }

            return ValidationResult.Success;
        }
    }
}