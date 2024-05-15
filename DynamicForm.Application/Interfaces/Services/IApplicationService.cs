using DynamicForm.Application.DTOs;
using DynamicForm.Bases;

namespace DynamicForm.Application.Interfaces.Services;

public interface IApplicationService
{
    Result<CreatedApplication> CreateNewForm(CreateApplication application);

    Result<ICollection<CreatedApplication>> GetApplications(CreateApplication application);
}
