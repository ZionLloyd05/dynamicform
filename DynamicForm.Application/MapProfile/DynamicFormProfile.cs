using AutoMapper;
using DynamicForm.Application.DTOs;
using DynamicForm.Domain.Models;

namespace DynamicForm.Application.MapProfile;

public class DynamicFormProfile : Profile
{
    public DynamicFormProfile()
    {
        CreateMap<ApplicationForm, CreatedApplicationForm>();

        CreateMap<FieldComponent, CreatedFieldComponent>();

        CreateMap<FieldComponentValidation, CreatedFieldComponentValidator>();

        CreateMap<FieldComponent, CreatedFieldComponent>();

        CreateMap<FieldMetaData, CreatedFieldMetaData>();
    }
}
