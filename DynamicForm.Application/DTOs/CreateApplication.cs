namespace DynamicForm.Application.DTOs;

public class CreateApplication
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public ICollection<CreateFieldComponent> FieldComponents { get; set; }
       = new List<CreateFieldComponent>();
}
