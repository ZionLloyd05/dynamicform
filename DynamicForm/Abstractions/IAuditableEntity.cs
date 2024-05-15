namespace DynamicForm.Abstractions;

public interface IAuditableEntity
{
    DateTime CreatedOn { get; set; }
    DateTime? ModifiedOn { get; set; }
}
