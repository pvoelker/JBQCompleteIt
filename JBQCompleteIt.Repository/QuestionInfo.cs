using System;
using System.Collections.Generic;

namespace JBQCompleteIt.Repository
{
    public class QuestionInfo
    {
        public int Number { get; set; }
        public required QuestionTypeEnum Type { get; set; }
        public required string Question { get; set; }
        public int AnswerHash { get; set; }
        public required List<string> Answer { get; set; }
        public List<string>? WrongAnswers { get; set; }
        public string? Passage { get; set; }
    }
}
