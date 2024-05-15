namespace DynamicForm.Domain.Models;

public class QuestionMetaData : BaseEntity<string>
{
    public string Label { get; set; } = string.Empty;
    public string Value { get; set; } = string.Empty;

    public string QuestionId { get; set; }
    public virtual Question Question { get; set; } = default!;
}