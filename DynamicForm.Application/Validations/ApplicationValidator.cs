using FluentValidation;

namespace DynamicForm.Application.Validations;

public class ApplicationValidator : AbstractValidator<Domain.Models.Application>
{
    public ApplicationValidator()
    {
        RuleFor(form => form.Title)
            .NotEmpty()
            .MinimumLength(3);

        RuleFor(form => form.Description)
            .NotEmpty()
            .MinimumLength(10)
            .MaximumLength(300);
    }
}
