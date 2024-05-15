using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicForm.Abstractions;

namespace DynamicForm.Domain.Models;

public class ProgramForm : BaseEntity<string>, IAuditableEntity
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public ICollection<FieldComponent> FieldComponents { get; set; }
        = new List<FieldComponent>();

    public DateTime CreatedOn { get; set; }
    public DateTime? ModifiedOn { get; set; }
}
