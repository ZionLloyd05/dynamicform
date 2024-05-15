using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicForm.Domain.Models;

public class FieldComponentValidation : BaseEntity<string>
{
    public bool IsRequired { get; set; }
    public bool IsInternal { get; set; }
    public int MinLength { get; set; }
    public int MaxLength { get; set; }
    public int MaxSelection { get; set; }
    public bool ShouldAllowOther { get; set; }
}
