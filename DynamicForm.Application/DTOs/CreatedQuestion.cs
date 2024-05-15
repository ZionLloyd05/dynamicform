using DynamicForm.Domain.Enums;

namespace DynamicForm.Application.DTOs;

public class CreatedQuestion
{
    public string Id { get; set; } = string.Empty;
    public string ApplicationFormId { get; set; } = string.Empty;
    public string Label { get; set; } = string.Empty;
    public string Placeholder { get; set; } = string.Empty;
    public QuestionType QuestionType { get; set; }
    public QuestionCategory QuestionCategory { get; set; }
    public CreatedQuestionValidator Validator { get; set; } = new();
    public ICollection<CreatedQuestionMetaData>? QuestionMetaData { get; set; }
}
