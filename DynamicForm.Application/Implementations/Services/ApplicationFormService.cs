﻿using AutoMapper;
using DynamicForm.Application.DTOs;
using DynamicForm.Application.Interfaces.Builders;
using DynamicForm.Application.Interfaces.Data;
using DynamicForm.Application.Interfaces.Services;
using DynamicForm.Bases;

namespace DynamicForm.Application.Implementations.Services;

public partial class ApplicationFormService : IApplicationFormService
{
    private readonly IApplicationFormBuilder applicationBuilder;
    private readonly IFieldComponentBuilder fieldComponentBuilder;
    private readonly IRepository repository;

    public ApplicationFormService(
        IApplicationFormBuilder applicationBuilder,
        IFieldComponentBuilder fieldComponentBuilder,
        IRepository repository)
    {
        this.applicationBuilder = applicationBuilder;
        this.fieldComponentBuilder = fieldComponentBuilder;
        this.repository = repository;
    }

    public Result<CreatedApplicationForm> CreateNewForm(CreateApplicationForm application)
    {
        var newApplicationResult = applicationBuilder
            .AddFormDetails(
                title: application.Title,
                description: application.Description)
            .AddFieldComponents(
                fieldComponents: application.FieldComponents)
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

    public Result<ICollection<CreatedApplicationForm>> GetApplications(CreateApplicationForm application)
    {
        throw new NotImplementedException();
    }
}
