﻿using FluentValidation;

namespace DynamicForm.Application.Validations;

public class ApplicationFormValidator : AbstractValidator<Domain.Models.ApplicationForm>
{
    public ApplicationFormValidator()
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