using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicForm.Abstractions;

namespace DynamicForm.Domain.Models;

public class BaseEntity<TId> : IEntity<TId>
{
    public TId Id { get; set; }

    protected BaseEntity()
    {
    }

    protected BaseEntity(TId id)
    {
        Id = id;
    }
}
