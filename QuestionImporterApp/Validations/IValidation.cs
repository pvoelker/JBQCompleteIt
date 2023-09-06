using System;

namespace QuestionImporterApp.Validations
{
    public interface IValidation
    {
        string Name { get; }

        IEnumerable<string> Validate(IEnumerable<QuestionSheetRow> rows);
    }
}
