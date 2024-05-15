using DynamicForm.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DynamicForm.Infrastructure.Configurations;

public class QuestionConfiguration
{
    public void Configure(EntityTypeBuilder<Question> builder)
    {
        builder.HasKey(x => x.Id);

        builder.OwnsOne(x => x.Validator);
        builder.OwnsMany(x => x.QuestionMetaData);
    }
}
