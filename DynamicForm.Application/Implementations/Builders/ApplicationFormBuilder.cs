using System.Text;
using DynamicForm.Application.DTOs;
using DynamicForm.Application.Interfaces.Builders;
using DynamicForm.Bases;
using DynamicForm.Domain.Models;
using FluentValidation;

namespace DynamicForm.Application.Implementations.Builders;

public class ApplicationFormBuilder : IApplicationFormBuilder
{
    private readonly Domain.Models.ApplicationForm form;

    private StringBuilder formErrors;
    private bool hasErrors = false;
    private readonly IValidator<Domain.Models.ApplicationForm> formValidator;
    private readonly IValidator<FieldComponent> fieldValidator;

    public ApplicationFormBuilder(
        IValidator<Domain.Models.ApplicationForm> formValidator,
        IValidator<FieldComponent> fieldValidator)
    {
        this.formValidator = formValidator;
        this.fieldValidator = fieldValidator;
        formErrors = new StringBuilder();
        form = new Domain.Models.ApplicationForm();
    }

    public IApplicationFormBuilder AddFormDetails(string title, string description)
    {
        form.Title = title;
        form.Description = description;

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

    public IApplicationFormBuilder AddFieldComponents(ICollection<CreateFieldComponent> fieldComponents)
    {
        foreach (var field in fieldComponents)
        {
            var fieldBuilder = new FieldComponentBuilder(fieldValidator);

            var fieldResult = fieldBuilder
                .AddFieldKey(Guid.NewGuid().ToString())
                .AddFieldDetails(
                    label: field.Label,
                    placeholder: field.Placeholder,
                    questionCategory: field.QuestionCategory,
                    questionType: field.QuestionType)
                .AddFieldMetadata(
                    fieldMetaData: field.FieldMetaData)
                .AddFieldValidators(
                    validator: field.Validator)
                .BuildFieldComponent();

            if (fieldResult.HasError)
            {
                formErrors.AppendLine(fieldResult.Error.FullMessage);
                hasErrors = true;
            }

            var newField = fieldResult.Value!;

            form.FieldComponents.Add(newField);
        }
        return this;
    }

    public Result<Domain.Models.ApplicationForm> BuildForm()
    {
        var validationErrors = formErrors.ToString();

        if (hasErrors)
        {
            return new Error(validationErrors.ToString(), "Invalid.Form", false);
        }

        form.Id = Guid.NewGuid().ToString();
        return form;
    }
}
