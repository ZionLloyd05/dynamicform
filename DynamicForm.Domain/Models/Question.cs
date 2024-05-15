using DynamicForm.Domain.Enums;

namespace DynamicForm.Domain.Models;

public class Question : BaseEntity<string>
{
    public string Label { get; set; } = string.Empty;
    public string Placeholder { get; set; } = string.Empty;
    public QuestionType QuestionType { get; set; }
    public QuestionCategory QuestionCategory { get; set; }
    public QuestionValidation Validator { get; set; } = new();
    public ICollection<QuestionMetaData>? QuestionMetaData { get; set; }

    public string ApplicationFormId { get; set; }
    public virtual ApplicationForm ApplicationForm { get; set; } = default!;
}
