namespace DynamicForm.Application.DTOs;

public class CreatedApplicationForm
{
    public string Id { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public ICollection<CreatedFieldComponent> FieldComponents { get; set; }
       = new List<CreatedFieldComponent>();
}
