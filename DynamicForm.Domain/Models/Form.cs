using DynamicForm.Abstractions;

namespace DynamicForm.Domain.Models;

public class Form : BaseEntity<string>, IAuditableEntity
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public ICollection<FieldComponent> FieldComponents { get; set; }
        = new List<FieldComponent>();

    public DateTime CreatedOn { get; set; }
    public DateTime? ModifiedOn { get; set; }
}
