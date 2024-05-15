using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicForm.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DynamicForm.Infrastructure.Configurations;

public class ProgramFormConfiguration : IEntityTypeConfiguration<ProgramForm>
{ 
    public void Configure(EntityTypeBuilder<ProgramForm> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Title)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.Description)
            .IsRequired()
            .HasMaxLength(1000);

        builder.OwnsMany(x => x.FieldComponents);

        builder.ToContainer("ProgramForms")
            .HasPartitionKey(p => p.Id);
    }
}
