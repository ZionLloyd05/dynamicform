namespace DynamicForm.Application.DTOs;

public class CreateApplicationForm
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public ICollection<CreateQuestion> Questions { get; set; }
       = new List<CreateQuestion>();
}
