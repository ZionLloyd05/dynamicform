using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicForm.Application.DTOs;
using DynamicForm.Application.Validations;
using DynamicForm.Bases;

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
}
