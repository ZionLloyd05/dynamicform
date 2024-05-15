using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicForm.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DynamicForm.Infrastructure.Configurations;

public class SubmissionConfiguration : IEntityTypeConfiguration<ApplicationSubmission>
{
    public void Configure(EntityTypeBuilder<ApplicationSubmission> builder)
    {
        builder.HasKey(x => x.Id);

        builder.ToContainer("Submissions")
            .HasPartitionKey(p => p.Id);
    }
}