using DynamicForm.Domain.Models;
using FluentValidation;

namespace DynamicForm.Application.Validations;

public class SubmissionValidator : AbstractValidator<ApplicationSubmission>
{
    public SubmissionValidator()
    {
        RuleFor(field => field.ApplicationId)
            .NotEmpty()
            .WithMessage("application id cannot be empty");

        RuleFor(field => field.UserData)
            .Must(field => field?.Count > 0)
            .WithMessage("Submission must contain application information");
    }
}
