using System;

namespace QuestionImporterApp.Validations
{
    public class AllQuestionsHaveAnswers : IValidation
    {
        public string Name { get => "All questions must have wrong answers provided or specify a question type"; }

        public IEnumerable<string> Validate(IEnumerable<QuestionSheetRow> rows)
        {
            var problems = rows.Where(x => string.IsNullOrEmpty(x.Type) && string.IsNullOrEmpty(x.WrongAnswers));

            return problems.Select(x => $"Question '{x.Number}' has no wrong answers or type specified").ToList();
        }
    }
}
