using DynamicForm.Application.Const;
using FluentValidation;

namespace DynamicForm.Application.Validations;

public class ApplicationFormValidator : AbstractValidator<Domain.Models.ApplicationForm>
{
    public ApplicationFormValidator()
    {
        RuleFor(form => form.Title)
            .NotEmpty()
            .MinimumLength(3)
            .WithMessage(Messages.TITLE_ERROR);

        RuleFor(form => form.Description)
            .NotEmpty()
            .MinimumLength(10)
            .MaximumLength(300)
            .WithMessage(Messages.DESCRIPTION_ERROR);
    }
}
