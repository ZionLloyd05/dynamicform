using System.Text;
using DynamicForm.Application.Const;
using DynamicForm.Application.DTOs;
using DynamicForm.Application.Interfaces.Builders;
using DynamicForm.Application.Validations;
using DynamicForm.Bases;

namespace DynamicForm.Application.Implementations.Builders;

public class ApplicationFormBuilder : IApplicationFormBuilder
{
    private readonly Domain.Models.ApplicationForm form;

    private StringBuilder formErrors;
    private bool hasErrors = false;

    public ApplicationFormBuilder()
    {
        formErrors = new StringBuilder();
        form = new Domain.Models.ApplicationForm();
    }

    /// <summary>
    /// Add details to application form
    /// </summary>
    /// <param name="title"></param>
    /// <param name="description"></param>
    /// <returns></returns>
    public IApplicationFormBuilder AddFormDetails(string title, string description)
    {
        form.Title = title;
        form.Description = description;

        var formValidator = new ApplicationFormValidator();
        var validationResult = formValidator.Validate(form);

        if (!validationResult.IsValid)
        {
            var errors = new StringBuilder();
            foreach (var error in validationResult.Errors)
            {
                errors.Append($"{error.PropertyName} - {error.ErrorMessage} | ");
            }

            formErrors.Append(errors.ToString());
            hasErrors = true;
        }

        return this;
    }

    /// <summary>
    /// Add questions to application form
    /// </summary>
    /// <param name="fieldComponents"></param>
    /// <returns></returns>
    public IApplicationFormBuilder AddQuestions(ICollection<CreateQuestion> fieldComponents)
    {
        foreach (var field in fieldComponents)
        {
            var fieldBuilder = new QuestionBuilder();

            var fieldResult = fieldBuilder
                .AddFieldKey(Guid.NewGuid().ToString())
                .AddFieldDetails(
                    label: field.Label,
                    placeholder: field.Placeholder,
                    questionCategory: field.QuestionCategory,
                    questionType: field.QuestionType)
                .AddFieldMetadata(
                    fieldMetaData: field.QuestionMetaData)
                .AddFieldValidators(
                    validator: field.Validator)
                .BuildFieldComponent();

            if (fieldResult.HasError)
            {
                formErrors.AppendLine(fieldResult.Error.FullMessage);
                hasErrors = true;
            }

            var newField = fieldResult.Value!;

            form.Questions.Add(newField);
        }
        return this;
    }

    public Result<Domain.Models.ApplicationForm> BuildForm()
    {
        var validationErrors = formErrors.ToString();

        if (hasErrors)
        {
            return new Error(validationErrors.ToString(), ErrorCodes.INVALID_FORM, false);
        }

        form.Id = Guid.NewGuid().ToString();
        return form;
    }
}
