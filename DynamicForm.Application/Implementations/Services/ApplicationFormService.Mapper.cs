using DynamicForm.Application.DTOs;
using DynamicForm.Domain.Models;

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
            Questions = application.Questions.Select(field => new CreatedQuestion
            {
                Id = field.Id,
                ApplicationFormId = application.Id,
                Label = field.Label,
                Placeholder = field.Placeholder,
                QuestionCategory = field.QuestionCategory,
                QuestionType = field.QuestionType,
                Validator = new CreatedQuestionValidator
                {
                    Id = field.Validator.Id,
                    QuestionId = field.Id,
                    IsRequired = field.Validator.IsRequired,
                    IsInternal = field.Validator.IsInternal,
                    MinLength = field.Validator.MinLength,
                    MaxLength = field.Validator.MaxLength,
                    MaxSelection = field.Validator.MaxLength,
                    ShouldAllowOther = field.Validator.ShouldAllowOther,
                },
                QuestionMetaData = field.QuestionMetaData?.Select(data => new CreatedQuestionMetaData
                {
                    Id = data.Id,
                    QuestionId = field.Id,
                    Label = data.Label,
                    Value = data.Value,
                }).ToList()
            }).ToList()
        };

        return convertedApplicationForm;
    }

    Question MapFrom(Question originalQuestion, UpdateQuestion question)
    {
        originalQuestion.Label = question.Label;
        originalQuestion.Placeholder = question.Placeholder;
        originalQuestion.QuestionCategory = question.QuestionCategory;
        originalQuestion.QuestionType = question.QuestionType;
        originalQuestion.Validator.IsRequired = question.Validator.IsRequired;
        originalQuestion.Validator.IsInternal = question.Validator.IsInternal;
        originalQuestion.Validator.MinLength = question.Validator.MinLength;
        originalQuestion.Validator.MaxLength = question.Validator.MaxLength;
        originalQuestion.Validator.ShouldAllowOther = question.Validator.ShouldAllowOther;
        originalQuestion.QuestionMetaData = question.QuestionMetaData?.Select(data => new QuestionMetaData
        {
            Id = Guid.NewGuid().ToString(),
            QuestionId = originalQuestion.Id,
            Label = data.Label,
            Value = data.Value,
        }).ToList();

        return originalQuestion;
    }
}
