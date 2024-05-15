﻿using System.Text;
using DynamicForm.Application.DTOs;
using DynamicForm.Application.Interfaces.Builders;
using DynamicForm.Bases;
using DynamicForm.Domain.Enums;
using DynamicForm.Domain.Models;
using FluentValidation;

namespace DynamicForm.Application.Implementations.Builders;

public class FieldComponentBuilder : IFieldComponentBuilder
{
    private readonly FieldComponent fieldComponent;
    private readonly IValidator<FieldComponent> validator;
    private StringBuilder fieldErrors;
    private bool hasErrors;

    public FieldComponentBuilder(IValidator<FieldComponent> validator)
    {
        this.validator = validator;

        fieldErrors = new StringBuilder();
        fieldComponent = new FieldComponent();
        hasErrors = false;
    }

    /// <summary>
    /// Add a key to uniquely identify this form
    /// </summary>
    /// <param name="key"></param>
    /// <returns>IFieldComponentBuilder</returns>
    public IFieldComponentBuilder AddFieldKey(string key)
    {
        if (string.IsNullOrEmpty(key))
            return this;

        fieldComponent.Id = key;

        return this;
    }

    /// <summary>
    /// Add field component properties
    /// </summary>
    /// <param name="label"></param>
    /// <param name="placeholder"></param>
    /// <param name="questionCategory"></param>
    /// <param name="questionType"></param>
    /// <returns>IFieldComponentBuilder</returns>
    public IFieldComponentBuilder AddFieldDetails(string label, string placeholder, QuestionCategory questionCategory, QuestionType questionType)
    {
        fieldComponent.Label = label;
        fieldComponent.Placeholder = placeholder;
        fieldComponent.QuestionCategory = questionCategory;
        fieldComponent.QuestionType = questionType;

        return this;
    }

    /// <summary>
    /// Set field component validator properties
    /// </summary>
    /// <param name="validator"></param>
    /// <returns>IFieldComponentBuilder</returns>
    public IFieldComponentBuilder AddFieldValidators(CreateFieldComponentValidator validator)
    {
        fieldComponent.Validator = new FieldComponentValidation
        {
            IsInternal = validator.IsInternal,
            IsRequired = validator.IsRequired,
            MinLength = validator.MinLength,
            MaxLength = validator.MaxLength,
            MaxSelection = validator.MaxSelection,
            ShouldAllowOther = validator.ShouldAllowOther,
        };

        return this;
    }

    /// <summary>
    /// Add all metadata attached to a field component
    /// </summary>
    /// <param name="fieldMetaData"></param>
    /// <returns>IFieldComponentBuilder</returns>
    public IFieldComponentBuilder AddFieldMetadata(ICollection<CreateFieldMetaData>? fieldMetaData)
    {

        if (fieldMetaData == null)
            return this;

        fieldComponent.FieldMetaData = fieldMetaData.Select(fv => new FieldMetaData
        {
            Id = Guid.NewGuid().ToString(),
            Label = fv.Label,
            Value = fv.Value,
            FieldComponentId = fieldComponent.Id
        }).ToList();

        var validationResult = validator.Validate(fieldComponent);

        if (!validationResult.IsValid)
        {
            var errors = new StringBuilder();
            foreach (var error in validationResult.Errors)
            {
                errors.Append($"{error.PropertyName} - {error.ErrorMessage} | ");
            }

            fieldErrors.Append(errors.ToString());
            hasErrors = true;
        }


        return this;
    }

    /// <summary>
    /// Build Field Component
    /// </summary>
    /// <returns>Result of FieldComponent</returns>
    public Result<FieldComponent> BuildFieldComponent()
    {
        var validationErrors = fieldErrors.ToString();

        if (hasErrors)
        {
            return new Error(validationErrors.ToString(), "Invalid.Field", false);
        }

        return fieldComponent;
    }
}
