using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DynamicForm.Application.DTOs;
using DynamicForm.Application.Interfaces.Builders;
using DynamicForm.Application.Interfaces.Services;
using DynamicForm.Bases;

namespace DynamicForm.Application.Implementations.Services;

public class ApplicationService : IApplicationService
{
    private readonly IApplicationBuilder applicationBuilder;
    private readonly IFieldComponentBuilder fieldComponentBuilder;
    private readonly IMapper mapper;

    public ApplicationService(
        IApplicationBuilder applicationBuilder,
        IFieldComponentBuilder fieldComponentBuilder,
        IMapper mapper)
    {
        this.applicationBuilder = applicationBuilder;
        this.fieldComponentBuilder = fieldComponentBuilder;
        this.mapper = mapper;
    }

    public Result<CreatedApplication> CreateNewForm(CreateApplication application)
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

        var newApplicationForReturn = mapper.Map<CreatedApplication>(newApplication);

        return newApplicationForReturn;
    }

    public Result<ICollection<CreatedApplication>> GetApplications(CreateApplication application)
    {
        throw new NotImplementedException();
    }
}
