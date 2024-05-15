﻿using DynamicForm.Domain.Enums;

namespace DynamicForm.Application.DTOs;

public class CreateFieldComponent
{
    public string Label { get; set; } = string.Empty;
    public string Placeholder { get; set; } = string.Empty;
    public QuestionType QuestionType { get; set; }
    public QuestionCategory QuestionCategory { get; set; }
    public CreateFieldComponentValidator Validator { get; set; } = new();
    public ICollection<CreateFieldMetaData>? FieldMetaData { get; set; }
}
