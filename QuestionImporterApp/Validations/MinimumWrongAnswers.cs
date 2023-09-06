using System;

namespace QuestionImporterApp.Validations
{
    public class MinimumWrongAnswers : IValidation
    {
        public string Name { get => "Check for a minimum number of wrong answers provided"; }

        public IEnumerable<string> Validate(IEnumerable<QuestionSheetRow> rows)
        {
            var problems = rows.Where(x => x.HasWrongAnswers).Where(x => x.WrongAnswersAsList().Count() < 4);

            return problems.Select(x => $"Question '{x.Number}' has fewer than four (4) wrong answers associated with it---{x.WrongAnswers}").ToList();
        }
    }
}
