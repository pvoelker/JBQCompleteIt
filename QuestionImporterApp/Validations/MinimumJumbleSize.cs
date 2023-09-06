using System;

namespace QuestionImporterApp.Validations
{
    public class MinimumJumbleSize : IValidation
    {
        public string Name { get => "Check Jumble question types for a minimum size"; }

        public IEnumerable<string> Validate(IEnumerable<QuestionSheetRow> rows)
        {
            var jumbles = rows.Where(x => x.Type == "Jumble");

            if(!jumbles.Any())
            {
                return new List<string> { "No jumble question types are detected" };
            }

            var problems = jumbles.Where(x => x.Answer.Split(' ').Count() < 4);

            return problems.Select(x => $"Question '{x.Number}' is a Jumble type with less than 4 elements").ToList();
        }
    }
}
