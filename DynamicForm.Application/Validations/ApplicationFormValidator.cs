using FluentValidation;

namespace DynamicForm.Application.Validations;

public class ApplicationFormValidator : AbstractValidator<Domain.Models.ApplicationForm>
{
    public ApplicationFormValidator()
    {
        RuleFor(form => form.Title)
            .NotEmpty()
            .MinimumLength(3)
            .WithMessage("title cannot be empty");

        RuleFor(form => form.Description)
            .NotEmpty()
            .MinimumLength(10)
            .MaximumLength(300);
    }
}
