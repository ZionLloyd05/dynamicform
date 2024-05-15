using System.Text;
using DynamicForm.Application.DTOs;
using DynamicForm.Application.Validations;
using DynamicForm.Bases;
using DynamicForm.Domain.Models;

namespace DynamicForm.Application.Implementations.Services;

public partial class ApplicationFormService
{
    public Result ValidateQuestion(UpdateQuestion question)
    {
        UpdateAppQuestionValidator validator = new UpdateAppQuestionValidator();
        var validationResult = validator.Validate(question);

        if (!validationResult.IsValid)
        {
            var errors = new StringBuilder();
            foreach (var error in validationResult.Errors)
            {
                errors.Append($"{error.PropertyName} - {error.ErrorMessage} | ");
            }

            return new Error(errors.ToString(), "Invalid.Question", false);

        }

        return new Success();
    }

    public Result ValidateSubmission(ApplicationSubmission submission)
    {
        SubmissionValidator validator = new SubmissionValidator();
        var validationResult = validator.Validate(submission);

        if (!validationResult.IsValid)
        {
            var errors = new StringBuilder();
            foreach (var error in validationResult.Errors)
            {
                errors.Append($"{error.PropertyName} - {error.ErrorMessage} | ");
            }

            return new Error(errors.ToString(), "Invalid.Question", false);

        }

        return new Success();
    }
}
