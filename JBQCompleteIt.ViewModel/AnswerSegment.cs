using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;

namespace JBQCompleteIt.ViewModel
{
    public class AnswerSegment : ObservableObject
    {
        /// <summary>
        /// True if the answer segment is 'pre-answered' based on game difficulty settings
        /// </summary>
        private bool _preAnswered = false;
        public bool PreAnswered
        {
            get => _preAnswered;
            set => SetProperty(ref _preAnswered, value);
        }

        /// <summary>
        /// Correct order index for the answer segment.  Null if segment is not part of answer
        /// </summary>
        private int? _index = null;
        public int? Index
        {
            get => _index;
            set
            {
                SetProperty(ref _index, value);
                OnPropertyChanged(nameof(IsPartOfAnswer));
                OnPropertyChanged(nameof(IsNotPartOfAnswer));
            }
        }

        public bool IsPartOfAnswer
        {
            get => _index.HasValue;
        }

        public bool IsNotPartOfAnswer
        {
            get => !_index.HasValue;
        }

        private List<int> _correctIndexes;
        /// <summary>
        /// Correct order indexes of segment in complete answer. Null if not part of answer
        /// </summary>
        /// <remarks>It is possible to have multiple correct indexes if words are repeated in the answer</remarks>
        public List<int> CorrectIndexes
        {
            get => _correctIndexes;
            set
            {
                SetProperty(ref _correctIndexes, value);
                OnPropertyChanged(nameof(IsOrderGivenWrong));
            }
        }

        private int? _givenIndex;
        /// <summary>
        /// Given order index of segment in complete answer from the user.  Null if no given order from the user
        /// </summary>
        public int? GivenIndex
        {
            get => _givenIndex;
            set
            {
                WasWrong = IsOrderGivenWrong;

                SetProperty(ref _givenIndex, value);
                OnPropertyChanged(nameof(IsOrderGivenWrong));
                OnPropertyChanged(nameof(IsOrderGiven));
                OnPropertyChanged(nameof(IsOrderNotGiven));
            }
        }

        public bool IsOrderGiven
        {
            get => GivenIndex.HasValue;
        }

        public bool IsOrderNotGiven
        {
            get => !GivenIndex.HasValue;
        }

        public bool IsOrderGivenWrong
        {
            get => IsOrderGiven && (CorrectIndexes == null || !CorrectIndexes.Any(x => x == GivenIndex));
        }

        private string _text = null;
        /// <summary>
        /// Answer segment text
        /// </summary>
        public string Text
        {
            get => _text;
            set
            {
                SetProperty(ref _text, value);
                OnPropertyChanged(nameof(IsBlank));
            }
        }

        public bool IsBlank
        {
            get => string.IsNullOrEmpty(_text);
        }

        private bool _wasWrong = false;
        public bool WasWrong
        {
            get => _wasWrong;
            private set => SetProperty(ref _wasWrong, value);
        }

        #region Commands

        /// <summary>
        /// Command for when the answer is selected as the possible correct answer
        /// </summary>
        public IAsyncRelayCommand Clicked { get; set; }

        /// <summary>
        /// Command for to show a subtle hint
        /// </summary>
        public IAsyncRelayCommand ShowHint { get; set; }

        #endregion
    }
}
