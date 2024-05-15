using AutoMapper;
using DynamicForm.Application.DTOs;
using DynamicForm.Domain.Models;

namespace DynamicForm.Application.MapProfile;

public class DynamicFormProfile : Profile
{
    public DynamicFormProfile()
    {
        CreateMap<ApplicationForm, CreatedApplicationForm>();

        CreateMap<Question, CreatedQuestion>();

        CreateMap<QuestionValidation, CreatedQuestionValidator>();

        CreateMap<Question, CreatedQuestion>();

        CreateMap<QuestionMetaData, CreatedQuestionMetaData>();
    }
}
