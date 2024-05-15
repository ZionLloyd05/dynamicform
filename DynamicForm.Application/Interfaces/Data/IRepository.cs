using DynamicForm.Domain.Models;

namespace DynamicForm.Application.Interfaces.Data;

public interface IRepository
{
    void AddApplicationForm(ApplicationForm applicationForm);

    Task SaveApplicationFormAsync();

    Task<IEnumerable<ApplicationForm>> RetrieveApplications();
}
