using System;

namespace JBQCompleteIt.ViewModel
{
    /// <summary>
    /// The difficulty to run the game at
    /// </summary>
    public enum DifficultyEnum
    {
        /// <summary>
        /// 75% of Jumble elements are already filled in
        /// </summary>
        Easy = 0,
        /// <summary>
        /// 50% of Jumble elements are already filled in
        /// </summary>
        Normal = 1,
        /// <summary>
        /// None of Jumble elements are already filled in
        /// </summary>
        Hard = 2
    }
}
