using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicForm.Domain.Models;

public class FieldMetaData : BaseEntity<string>
{
    public string Label { get; set; } = string.Empty;
    public string Value { get; set; } = string.Empty;

    public string FieldComponentId { get; set; }
    public virtual FieldComponent FieldComponent { get; set; } = default!;
}