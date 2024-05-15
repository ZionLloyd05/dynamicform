using System.Text;
using DynamicForm.Application.DTOs;
using DynamicForm.Application.Interfaces.Builders;
using DynamicForm.Application.Validations;
using DynamicForm.Bases;
using DynamicForm.Domain.Enums;
using DynamicForm.Domain.Models;
using FluentValidation;

namespace DynamicForm.Application.Implementations.Builders;

public class QuestionBuilder : IQuestionBuilder
{
    private readonly Question question;
    private StringBuilder questionErrors;
    private bool hasErrors;

    public QuestionBuilder()
    {
        questionErrors = new StringBuilder();
        question = new Question();
        hasErrors = false;
    }

    /// <summary>
    /// Add a key to uniquely identify this form
    /// </summary>
    /// <param name="key"></param>
    /// <returns>IFieldComponentBuilder</returns>
    public IQuestionBuilder AddFieldKey(string key)
    {
        if (string.IsNullOrEmpty(key))
            return this;

        question.Id = key;

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
    public IQuestionBuilder AddFieldDetails(string label, string placeholder, QuestionCategory questionCategory, QuestionType questionType)
    {
        question.Label = label;
        question.Placeholder = placeholder;
        question.QuestionCategory = questionCategory;
        question.QuestionType = questionType;

        return this;
    }

    /// <summary>
    /// Set field component validator properties
    /// </summary>
    /// <param name="validator"></param>
    /// <returns>IFieldComponentBuilder</returns>
    public IQuestionBuilder AddFieldValidators(CreateQuestionValidator validator)
    {
        question.Validator = new QuestionValidation
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
    public IQuestionBuilder AddFieldMetadata(ICollection<CreateQuestionMetaData>? fieldMetaData)
    {

        if (fieldMetaData == null)
            return this;

        question.QuestionMetaData = fieldMetaData.Select(fv => new QuestionMetaData
        {
            Id = Guid.NewGuid().ToString(),
            Label = fv.Label,
            Value = fv.Value,
            QuestionId = question.Id
        }).ToList();

        QuestionValidator validator = new QuestionValidator();
        var validationResult = validator.Validate(question);

        if (!validationResult.IsValid)
        {
            var errors = new StringBuilder();
            foreach (var error in validationResult.Errors)
            {
                errors.Append($"{error.PropertyName} - {error.ErrorMessage} | ");
            }

            questionErrors.Append(errors.ToString());
            hasErrors = true;
        }


        return this;
    }

    /// <summary>
    /// Build Field Component
    /// </summary>
    /// <returns>Result of FieldComponent</returns>
    public Result<Question> BuildFieldComponent()
    {
        var validationErrors = questionErrors.ToString();

        if (hasErrors)
        {
            return new Error(validationErrors.ToString(), "Invalid.Field", false);
        }

        return question;
    }
}
