using DynamicForm.Application.DTOs;
using DynamicForm.Bases;
using DynamicForm.Domain.Enums;
using DynamicForm.Domain.Models;

namespace DynamicForm.Application.Interfaces.Builders;

public interface IQuestionBuilder
{
    IQuestionBuilder AddFieldKey(
        string key);

    IQuestionBuilder AddFieldDetails(
        string label,
        string placeholder,
        QuestionCategory questionCategory,
        QuestionType questionType);

    IQuestionBuilder AddFieldMetadata(
        ICollection<CreateQuestionMetaData>? fieldMetaData);

    IQuestionBuilder AddFieldValidators(
        CreateQuestionValidator validator);

    Result<Question> BuildFieldComponent();
}
