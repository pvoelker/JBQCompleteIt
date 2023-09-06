using System;
using System.Collections.Generic;

namespace JBQCompleteIt.Repository
{
    // Inteface definition for quiz question repository
    public interface IQuestionRepository
    {
        /// <summary>
        /// Get minimum question number
        /// </summary>
        /// <returns>Minimum question number</returns>
        int GetMinNumber();

        /// <summary>
        /// Get maximum question number
        /// </summary>
        /// <returns>Maximum question number</returns>
        int GetMaxNumber();

        /// <summary>
        /// Get all questions
        /// </summary>
        /// <returns>An enumerable of all questions</returns>
        IEnumerable<QuestionInfo> GetAll();

        /// <summary>
        /// Get a single question by the question number
        /// </summary>
        /// <param name="number">The question number to retrieve</param>
        /// <returns>A question</returns>
        QuestionInfo? GetByNumber(int number);
    }
}
