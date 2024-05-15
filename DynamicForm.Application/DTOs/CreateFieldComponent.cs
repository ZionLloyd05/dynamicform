using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicForm.Domain.Enums;
using DynamicForm.Domain.Models;

namespace DynamicForm.Application.DTOs;

public class CreateFieldComponent
{
    public string Label { get; set; } = string.Empty;
    public string Placeholder { get; set; } = string.Empty;
    public QuestionType QuestionType { get; set; }
    public QuestionCategory QuestionCategory { get; set; }
    public string InputPropsMetadata { get; set; } = string.Empty;
    public CreateFieldComponentValidator Validator { get; set; } = new();
    public ICollection<FieldMetaData>? FieldMetaData { get; set; }
}
