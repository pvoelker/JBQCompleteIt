namespace JBQCompleteIt.Repository
{
    /// <summary>
    /// The different types of questions in the game
    /// </summary>
    public enum QuestionTypeEnum
    {
        None = 0,

        /// <summary>
        /// Word jumble
        /// </summary>
        Jumble,
        
        /// <summary>
        /// Quotation question
        /// </summary>
        QuotationQuestion,
        
        /// <summary>
        /// Multiple choice question
        /// </summary>
        MultipleChoice
    }
}
