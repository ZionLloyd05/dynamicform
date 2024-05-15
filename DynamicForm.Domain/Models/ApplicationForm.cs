using DynamicForm.Abstractions;

namespace DynamicForm.Domain.Models;

public class ApplicationForm : BaseEntity<string>, IAuditableEntity
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public ICollection<Question> Questions { get; set; }
        = new List<Question>();

    public DateTime CreatedOn { get; set; }
    public DateTime? ModifiedOn { get; set; }
}
