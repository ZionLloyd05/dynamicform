using DynamicForm.Domain.Enums;

namespace DynamicForm.Application.DTOs;

public class UpdateQuestion
{
    public string Label { get; set; } = string.Empty;
    public string Placeholder { get; set; } = string.Empty;
    public QuestionType QuestionType { get; set; }
    public QuestionCategory QuestionCategory { get; set; }
    public UpdateQuestionValidator Validator { get; set; } = new();
    public ICollection<UpdateQuestionMetaData>? QuestionMetaData { get; set; }
}
