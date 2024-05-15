using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicForm.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DynamicForm.Infrastructure.Configurations;

public class FieldComponentConfiguration
{
    public void Configure(EntityTypeBuilder<FieldComponent> builder)
    {
        builder.HasKey(x => x.Id);

        builder.OwnsOne(x => x.Validator);
        builder.OwnsMany(x => x.FieldMetaData);
    }
}
