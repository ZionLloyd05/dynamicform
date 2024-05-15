using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DynamicForm.Application.DTOs;

namespace DynamicForm.Application.MapProfile;

public class DynamicFormProfile : Profile
{
	public DynamicFormProfile()
	{
		CreateMap<Domain.Models.Application, CreatedApplication>()
			.ForMember(dest => dest.FieldComponents, opt => opt.MapFrom(
				src => src.FieldComponents));

        CreateMap<Domain.Models.FieldComponent, CreatedFieldComponent>()
            .ForMember(dest => dest.Validator, opt => opt.MapFrom(
                src => src.Validator));

        CreateMap<Domain.Models.FieldComponent, CreatedFieldComponent>()
            .ForMember(dest => dest.FieldMetaData, opt => opt.MapFrom(
                src => src.FieldMetaData));

        CreateMap<Domain.Models.FieldMetaData, CreatedFieldMetaData>();
    }
}
