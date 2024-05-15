using DynamicForm.Domain.Enums;

namespace DynamicForm.Application.DTOs;

public class CreateQuestion
{
    public string Label { get; set; } = string.Empty;
    public string Placeholder { get; set; } = string.Empty;
    public QuestionType QuestionType { get; set; }
    public QuestionCategory QuestionCategory { get; set; }
    public CreateQuestionValidator Validator { get; set; } = new();
    public ICollection<CreateQuestionMetaData>? QuestionMetaData { get; set; }
}
