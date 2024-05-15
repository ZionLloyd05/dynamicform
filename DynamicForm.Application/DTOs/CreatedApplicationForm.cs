namespace DynamicForm.Application.DTOs;

public class CreatedApplicationForm
{
    public string Id { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public ICollection<CreatedQuestion> Questions { get; set; }
       = new List<CreatedQuestion>();
}
