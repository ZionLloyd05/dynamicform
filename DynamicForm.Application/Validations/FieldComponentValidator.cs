﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicForm.Domain.Enums;
using DynamicForm.Domain.Models;
using FluentValidation;

namespace DynamicForm.Application.Validations;

public class FieldComponentValidator : AbstractValidator<FieldComponent>
{
	public FieldComponentValidator()
	{
        RuleFor(field => field.Label)
            .NotEmpty()
            .MinimumLength(3)
            .MaximumLength(30)
            .WithMessage("label cannot be empty");

        RuleFor(field => field.QuestionType)
            .IsInEnum()
            .WithMessage("question type not supported");

        RuleFor(field => field.QuestionCategory)
            .IsInEnum()
            .WithMessage("question category not supported");

        RuleFor(field => field.FieldMetaData)
            .Must(field => field?.Count > 0)
            .When(field => field.QuestionType == QuestionType.DropDown)
            .WithMessage("Options are needed in fields value for drop down question type");

        RuleFor(field => field.FieldMetaData)
            .Must(field => field?.Count == 2)
            .When(field => field.QuestionType == QuestionType.YesNo)
            .WithMessage("Options are needed in fields value for yes no question type");

        RuleFor(field => field.FieldMetaData)
            .Must(field => field?.Count > 0)
            .When(field => field.QuestionType == QuestionType.MultipleChoice)
            .WithMessage("Options are needed in fields value for multiple choice question type");
    }
}