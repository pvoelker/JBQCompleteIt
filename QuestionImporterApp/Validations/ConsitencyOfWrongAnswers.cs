using System;

namespace QuestionImporterApp.Validations
{
    public class ConsitencyOfWrongAnswers : IValidation
    {
        public string Name { get => "Check for consistency in the punctuation in the wrong answers"; }

        public IEnumerable<string> Validate(IEnumerable<QuestionSheetRow> rows)
        {
            var rowsToCheck = rows.Where(x => x.HasWrongAnswers);

            var rowsWithAnswersThatEndWithPeriod = rowsToCheck.Where(x => x.Answer.EndsWith('.'));

            var rowsWithAnswersThatDontEndWithPeriod = rowsToCheck.Where(x => !x.Answer.EndsWith('.'));

            var problems = rowsWithAnswersThatEndWithPeriod.Where(x => x.WrongAnswersAsList().Any(y => !y.EndsWith('.')) ||
                x.WrongAnswersAsList().Any(y => !y.EndsWith('.')));

            problems.Concat(rowsWithAnswersThatDontEndWithPeriod.Where(x => x.WrongAnswersAsList().Any(y => !y.EndsWith('.')) ||
                x.WrongAnswersAsList().Any(y => y.EndsWith('.'))));

            return problems.Select(x => $"Question '{x.Number}' has inconsistency between the answer and wrong answers punctuation (period)").ToList();
        }
    }
}
