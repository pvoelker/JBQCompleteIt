using System;

namespace QuestionImporterApp.Validations
{
    public class AllAnswersHaveSingleSpaces : IValidation
    {
        public string Name { get => "All question answers must have single spacing"; }

        public IEnumerable<string> Validate(IEnumerable<QuestionSheetRow> rows)
        {
            var problems = rows.Where(x => x.Answer.Contains("  "));

            return problems.Select(x => $"Question '{x.Number}' has answer with more than single spacing").ToList();
        }
    }
}
