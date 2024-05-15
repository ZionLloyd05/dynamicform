using DynamicForm.Application.DTOs;
using DynamicForm.Bases;

namespace DynamicForm.Application.Interfaces.Services;

public interface IApplicationFormService
{
    Result<CreatedApplicationForm> CreateNewForm(CreateApplicationForm application);

    Task<Result<IReadOnlyCollection<CreatedApplicationForm>>> GetApplications();

    Task<Result<CreatedApplicationForm>> UpdateQuestionInApplication(
        string applicationId,
        string questionId,
        UpdateQuestion question);

    Task<Result> SaveSubmission(
        string applicationId,
        CreateApplicationSubmission applicationSubmission);
}
