using System;
using System.Collections.Generic;

namespace JBQCompleteIt.Repository
{
    internal class RawQuestionInfo
    {
        public int Number { get; set; }
        public required QuestionTypeEnum Type { get; set; }
        public required string Question { get; set; }
        public int AnswerHash { get; set; }
        public required int RawAnswerCount { get; set; }
        public required string RawAnswer { get; set; }
        public List<string>? WrongAnswers { get; set; }
        public string? Passage { get; set; }
    }
}
