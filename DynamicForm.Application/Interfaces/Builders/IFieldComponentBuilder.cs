using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using DynamicForm.Application.DTOs;
using DynamicForm.Bases;
using DynamicForm.Domain.Enums;
using DynamicForm.Domain.Models;

namespace DynamicForm.Application.Interfaces.Builders;

public interface IFieldComponentBuilder
{
    IFieldComponentBuilder AddFieldKey(
        string key);

    IFieldComponentBuilder AddFieldDetails(
        string label,
        string placeholder,
        QuestionCategory questionCategory,
        QuestionType questionType);

    IFieldComponentBuilder AddFieldValues(
        ICollection<CreateFieldMetaData>? fieldMetaData);

    IFieldComponentBuilder AddFieldValidators(
        CreateFieldComponentValidator validator);

    Result<FieldComponent> BuildFieldComponent();
}
