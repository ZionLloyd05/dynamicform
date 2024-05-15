using DynamicForm.Application.DTOs;
using DynamicForm.Bases;

namespace DynamicForm.Application.Interfaces.Builders;

public interface IApplicationBuilder
{
    IApplicationBuilder AddFormDetails(
        string title,
        string description);

    IApplicationBuilder AddFieldComponents(
        ICollection<CreateFieldComponent> fieldComponents);

    Result<Domain.Models.Application> BuildForm();
}
