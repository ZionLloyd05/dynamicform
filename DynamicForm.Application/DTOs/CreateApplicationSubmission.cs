using DynamicForm.Domain.Models;

namespace DynamicForm.Application.DTOs;

public class CreateApplicationSubmission
{
    public ICollection<UserData> UserData { get; set; } = new List<UserData>();
}
