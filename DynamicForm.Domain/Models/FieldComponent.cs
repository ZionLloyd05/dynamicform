﻿using DynamicForm.Domain.Enums;

namespace DynamicForm.Domain.Models;

public class FieldComponent : BaseEntity<string>
{
    public string Label { get; set; } = string.Empty;
    public string Placeholder { get; set; } = string.Empty;
    public QuestionType QuestionType { get; set; }
    public QuestionCategory QuestionCategory { get; set; }
    public FieldComponentValidation Validator { get; set; } = new();
    public ICollection<FieldMetaData>? FieldMetaData { get; set; }

    public string ProgramFormId { get; set; }
    public virtual Form ProgramForm { get; set; } = default!;
}