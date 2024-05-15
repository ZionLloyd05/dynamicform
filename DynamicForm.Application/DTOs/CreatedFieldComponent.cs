using DynamicForm.Domain.Enums;

namespace DynamicForm.Application.DTOs;

public class CreatedFieldComponent
{
    public string Id { get; set; } = string.Empty;
    public string ApplicationId { get; set; } = string.Empty;
    public string Label { get; set; } = string.Empty;
    public string Placeholder { get; set; } = string.Empty;
    public QuestionType QuestionType { get; set; }
    public QuestionCategory QuestionCategory { get; set; }
    public CreateFieldComponentValidator Validator { get; set; } = new();
    public ICollection<CreateFieldMetaData>? FieldMetaData { get; set; }
}
