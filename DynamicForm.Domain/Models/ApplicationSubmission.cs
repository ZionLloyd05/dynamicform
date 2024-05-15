using DynamicForm.Abstractions;
using DynamicForm.Domain.Enums;

namespace DynamicForm.Domain.Models;

public class ApplicationSubmission : BaseEntity<string>, IAuditableEntity
{
    public ICollection<UserData> UserData { get; set; }

    public string ApplicationId { get; set; } = string.Empty;
    public DateTime CreatedOn { get; set; }
    public DateTime? ModifiedOn { get; set; }
}

public class UserData
{
    public string PropertyName { get; set; } = string.Empty;
    public string PropertyValue { get; set; } = string.Empty;
    public QuestionType QuestionType { get; set; }
    public string QuestionId { get; set; } = string.Empty;
}