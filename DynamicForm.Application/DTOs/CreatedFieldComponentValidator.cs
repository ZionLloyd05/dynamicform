namespace DynamicForm.Application.DTOs;

public class CreatedFieldComponentValidator
{
    public string Id { get; set; } = string.Empty;
    public string FieldComponentId { get; set; } = string.Empty;
    public bool IsRequired { get; set; }
    public bool IsInternal { get; set; }
    public int MinLength { get; set; }
    public int MaxLength { get; set; }
    public int MaxSelection { get; set; }
    public bool ShouldAllowOther { get; set; }
}
