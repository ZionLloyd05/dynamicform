using System.Text;
using DynamicForm.Application.DTOs;
using DynamicForm.Application.Interfaces.Builders;
using DynamicForm.Application.Interfaces.Data;
using DynamicForm.Application.Interfaces.Services;
using DynamicForm.Bases;
using DynamicForm.Domain.Models;
using FluentValidation;

namespace DynamicForm.Application.Implementations.Services;

public partial class ApplicationFormService : IApplicationFormService
{
    private readonly IApplicationFormBuilder applicationBuilder;
    private readonly IQuestionBuilder fieldComponentBuilder;
    private readonly IRepository repository;
    private readonly IValidator<UpdateQuestion> validator;

    public ApplicationFormService(
        IApplicationFormBuilder applicationBuilder,
        IQuestionBuilder fieldComponentBuilder,
        IRepository repository,
        IValidator<UpdateQuestion> validator)
    {
        this.applicationBuilder = applicationBuilder;
        this.fieldComponentBuilder = fieldComponentBuilder;
        this.repository = repository;
        this.validator = validator;
    }

    public Result<CreatedApplicationForm> CreateNewForm(CreateApplicationForm application)
    {
        var newApplicationResult = applicationBuilder
            .AddFormDetails(
                title: application.Title,
                description: application.Description)
            .AddFieldComponents(
                fieldComponents: application.Questions)
            .BuildForm();

        if (newApplicationResult.HasError)
            return newApplicationResult.Error;

        var newApplication = newApplicationResult.Value;

        try
        {
            repository.AddApplicationForm(newApplication);
            repository.SaveApplicationFormAsync();
        }
        catch (Exception ex)
        {
            //@TODO: log exception somewhere
            return new Error(
                "unable to save for now, please re-try again",
                "Internal.Error",
                true);
        }

        var newApplicationForReturn = MapFrom(newApplication);

        return newApplicationForReturn;
    }

    public async Task<Result<IReadOnlyCollection<CreatedApplicationForm>>> GetApplications()
    {
        try
        {
            var applications = await repository.RetrieveApplications();
            ICollection<CreatedApplicationForm> applicationForms =
                applications.Select(form => MapFrom(form))
                .ToList();

            return applicationForms.ToList().AsReadOnly();
        }
        catch (Exception ex)
        {
            //@TODO: log exception somewhere
            return new Error(
                "unable to retrieve applications, please re-try again",
                "Internal.Error",
                true);
        }
    }

    public async Task<Result<CreatedApplicationForm>> UpdateQuestionInApplication(
        string applicationId,
        string questionId,
        UpdateQuestion question)
    {
        try
        {
            var validationResult = ValidateQuestion(question);
            if (validationResult.HasError)
                return validationResult.Error;

            var applicationInDb = await repository.GetApplicationAsync(applicationId);

            if (applicationInDb == null)
                return new Error(
                    $"application for with id {applicationId} does not exist",
                    "Not.Found",
                    false);

            var questionForUpdate = applicationInDb.Questions
                .Where(question => question.Id == questionId)
                .SingleOrDefault();

            if (questionForUpdate == null)
                return new Error(
                    $"question for with id {questionId} does not exist in application",
                    "Not.Found",
                    false);

            var updatedQuestion = MapFrom(questionForUpdate, question);

            applicationInDb.Questions
                .Remove(questionForUpdate);

            applicationInDb.Questions.Add(questionForUpdate);

            repository.UpdateApplicationForm(applicationInDb);
            await repository.SaveApplicationFormAsync();

            var updatedApplicationForm = MapFrom(applicationInDb);

            return updatedApplicationForm;
        }
        catch (Exception ex)
        {
            //@TODO: log exception somewhere
            return new Error(
                "unable to retrieve applications, please re-try again",
                "Internal.Error",
                true);
        }
    }
}
