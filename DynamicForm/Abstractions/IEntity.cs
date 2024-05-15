namespace DynamicForm.Abstractions;

public interface IEntity<TId>
{
    TId Id { get; set; }
}
