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

    IFieldComponentBuilder AddFieldMetadata(
        ICollection<CreateFieldMetaData>? fieldMetaData);

    IFieldComponentBuilder AddFieldValidators(
        CreateFieldComponentValidator validator);

    Result<FieldComponent> BuildFieldComponent();
}
