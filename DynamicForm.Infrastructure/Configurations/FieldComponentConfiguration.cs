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
