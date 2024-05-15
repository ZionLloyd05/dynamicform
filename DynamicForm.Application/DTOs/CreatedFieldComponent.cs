using DynamicForm.Domain.Enums;

namespace DynamicForm.Application.DTOs;

public class CreatedFieldComponent
{
    public string Id { get; set; } = string.Empty;
    public string ApplicationFormId { get; set; } = string.Empty;
    public string Label { get; set; } = string.Empty;
    public string Placeholder { get; set; } = string.Empty;
    public QuestionType QuestionType { get; set; }
    public QuestionCategory QuestionCategory { get; set; }
    public CreatedFieldComponentValidator Validator { get; set; } = new();
    public ICollection<CreatedFieldMetaData>? FieldMetaData { get; set; }
}
