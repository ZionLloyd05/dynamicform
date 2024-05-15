using DynamicForm.Application.DTOs;
using DynamicForm.Bases;

namespace DynamicForm.Application.Interfaces.Builders;

public interface IApplicationFormBuilder
{
    IApplicationFormBuilder AddFormDetails(
        string title,
        string description);

    IApplicationFormBuilder AddQuestions(
        ICollection<CreateQuestion> fieldComponents);

    Result<Domain.Models.ApplicationForm> BuildForm();
}
