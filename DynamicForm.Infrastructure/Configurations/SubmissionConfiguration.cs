using DynamicForm.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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