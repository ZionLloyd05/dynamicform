using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicForm.Domain.Models;
using FluentValidation;

namespace DynamicForm.Application.Validations;

public class FormValidator : AbstractValidator<Form>
{
    public FormValidator()
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
