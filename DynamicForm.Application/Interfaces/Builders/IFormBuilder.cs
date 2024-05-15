using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicForm.Application.DTOs;
using DynamicForm.Bases;
using DynamicForm.Domain.Models;

namespace DynamicForm.Application.Interfaces.Builders;

public interface IFormBuilder
{
    IFormBuilder AddFormDetails(
        string title,
        string description);

    IFormBuilder AddFieldComponents(
        ICollection<CreateFieldComponent> fieldComponents);

    Result<Form> BuildForm();
}
