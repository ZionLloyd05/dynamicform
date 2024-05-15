using DynamicForm.Domain.Models;

namespace DynamicForm.Application.Interfaces.Data;

public interface IRepository
{
    void AddApplicationForm(ApplicationForm applicationForm);

    Task CommitChangesAsync();

    Task<IEnumerable<ApplicationForm>> RetrieveApplications();

    Task<ApplicationForm?> GetApplicationAsync(string Id);

    void UpdateApplicationForm(ApplicationForm applicationForm);

    void AddSubmission(ApplicationSubmission submission);
}
