using System;

namespace QuestionImporterApp.Validations
{
    public class AllWrongAnswersHaveSingleSpaces : IValidation
    {
        public string Name { get => "All question wrong answers must have single spacing"; }

        public IEnumerable<string> Validate(IEnumerable<QuestionSheetRow> rows)
        {
            var problems = rows.Where(x => x.HasWrongAnswers).Where(x => x.WrongAnswersAsList().Any(x => x.Contains("  ")));

            return problems.Select(x => $"Question '{x.Number}' has wrong answers with more than single spacing").ToList();
        }
    }
}
