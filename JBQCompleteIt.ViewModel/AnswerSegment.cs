using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;

namespace JBQCompleteIt.ViewModel
{
    public class AnswerSegment : ObservableObject
    {
        private int _index = 0;
        public int Index
        {
            get => _index;
            set => SetProperty(ref _index, value);
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
                SetWasWrong();

                SetProperty(ref _correctIndexes, value);
                OnPropertyChanged(nameof(IsCorrect));
                OnPropertyChanged(nameof(IsWrong));
                OnPropertyChanged(nameof(HasCorrectIndexes));
            }
        }

        public bool HasCorrectIndexes
        {
            get => CorrectIndexes != null && CorrectIndexes.Count() > 0;
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
                SetWasWrong();

                SetProperty(ref _givenIndex, value);
                OnPropertyChanged(nameof(IsCorrect));
                OnPropertyChanged(nameof(IsWrong));
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

        private string _text;
        /// <summary>
        /// Answer segment text
        /// </summary>
        public string Text
        {
            get => _text;
            set => SetProperty(ref _text, value);
        }

        public bool IsCorrect
        {
            get => HasCorrectIndexes && CorrectIndexes.Any(x => x == Index);
        }

        public bool IsWrong
        {
            get => IsOrderGiven && CorrectIndexes != null && !CorrectIndexes.Any(x => x == GivenIndex);
        }

        private void SetWasWrong()
        {
            WasWrong = IsWrong;
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
