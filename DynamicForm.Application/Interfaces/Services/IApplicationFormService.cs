using DynamicForm.Application.DTOs;
using DynamicForm.Bases;

namespace DynamicForm.Application.Interfaces.Services;

public interface IApplicationFormService
{
    Result<CreatedApplicationForm> CreateNewForm(CreateApplicationForm application);

    Result<ICollection<CreatedApplicationForm>> GetApplications(CreateApplicationForm application);
}
