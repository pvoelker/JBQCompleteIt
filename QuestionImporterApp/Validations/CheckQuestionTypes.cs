using System;

namespace QuestionImporterApp.Validations
{
    public class CheckQuestionTypes : IValidation
    {
        public string Name { get => "Questions types must be valid"; }

        public IEnumerable<string> Validate(IEnumerable<QuestionSheetRow> rows)
        {
            var validTypes = new List<string>()
            {
                "QuotationQuestion",
                "MultipleChoice",
                "Jumble"
            };

            var problems = rows.Where(x => !validTypes.Any(y => y == x.Type));

            return problems.Select(x => $"Question number '{x.Number}' does not have a valid question type").ToList();
        }
    }
}
