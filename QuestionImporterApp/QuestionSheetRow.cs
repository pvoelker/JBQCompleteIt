using System;

namespace QuestionImporterApp
{
    public class QuestionSheetRow
    {
        public int Number { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public string WrongAnswers { get; set; }
        public bool HasWrongAnswers { get => !string.IsNullOrEmpty(WrongAnswers); }
        public string[] WrongAnswersAsList() { return string.IsNullOrEmpty(WrongAnswers) ? null : WrongAnswers.Split('|'); }
        public string Passage { get; set; }
        public string Type { get; set; }
    }
}
