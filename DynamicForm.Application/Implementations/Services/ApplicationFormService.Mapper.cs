using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicForm.Application.DTOs;
using DynamicForm.Domain.Models;
using Microsoft.AspNetCore.Builder;

namespace DynamicForm.Application.Implementations.Services;

public partial class ApplicationFormService
{
    CreatedApplicationForm MapFrom(ApplicationForm application)
    {
        var convertedApplicationForm = new CreatedApplicationForm
        {
            Id = application.Id,
            Title = application.Title,
            Description = application.Description,
            FieldComponents = application.FieldComponents.Select(field => new CreatedFieldComponent
            {
                Id = field.Id,
                ApplicationFormId = application.Id,
                Label = field.Label,
                Placeholder = field.Placeholder,
                QuestionCategory = field.QuestionCategory,
                QuestionType = field.QuestionType,
                Validator = new CreatedFieldComponentValidator
                {
                    Id = field.Validator.Id,
                    FieldComponentId = field.Id,
                    IsRequired = field.Validator.IsRequired,
                    IsInternal = field.Validator.IsInternal,
                    MinLength = field.Validator.MinLength,
                    MaxLength = field.Validator.MaxLength,
                    MaxSelection = field.Validator.MaxLength,
                    ShouldAllowOther = field.Validator.ShouldAllowOther,
                },
                FieldMetaData = field.FieldMetaData?.Select(data => new CreatedFieldMetaData
                {
                    Id = data.Id,
                    FieldComponentId = field.Id,
                    Label = data.Label,
                    Value = data.Value,
                }).ToList()
            }).ToList()
        };

        return convertedApplicationForm;
    }
}
