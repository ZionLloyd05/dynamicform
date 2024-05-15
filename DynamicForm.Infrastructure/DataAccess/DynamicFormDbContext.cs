using DynamicForm.Abstractions;
using DynamicForm.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DynamicForm.Infrastructure.DataAccess;

public class DynamicFormDbContext : DbContext
{
    public DynamicFormDbContext()
    {
    }

    public DynamicFormDbContext(DbContextOptions<DynamicFormDbContext> options) : base(options)
    {
    }

    public DbSet<ApplicationForm> ApplicationForms { get; set; } = default!;
    public DbSet<ApplicationSubmission> Submissions { get; set; } = default!;
    public DbSet<Question> QuestionComponents { get; set; } = default!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");

        var config = builder.Build();

        var dynamicFormSection = config.GetRequiredSection("DynamicFormConfig");

        var accountEndpoint = dynamicFormSection.GetSection("AccountEndpoint").Value ??
            throw new ArgumentNullException();
        var accountKey = dynamicFormSection.GetSection("AccountKey").Value ??
            throw new ArgumentNullException();
        var databaseName = dynamicFormSection.GetSection("DatabaseName").Value ??
            throw new ArgumentNullException();

        optionsBuilder.UseCosmos(
            accountEndpoint: accountEndpoint,
            accountKey: accountKey,
            databaseName: databaseName);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(typeof(DynamicFormDbContext).Assembly);
        base.OnModelCreating(builder);
    }
    public override int SaveChanges()
    {
        SetTimeStamps();
        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        SetTimeStamps();
        return base.SaveChangesAsync(cancellationToken);
    }

    private void SetTimeStamps()
    {
        ChangeTracker.DetectChanges();

        DateTime now = DateTime.UtcNow;

        foreach (var Product in ChangeTracker.Entries().Where(e => e.State == EntityState.Added))
        {
            if (Product.Entity is IAuditableEntity entity)
            {
                entity.CreatedOn = now;
            }
            if (Product.Entity is IAuditableEntity newEntity) newEntity.ModifiedOn = now;
        }

        foreach (var Product in ChangeTracker.Entries().Where(e => e.State == EntityState.Modified))
        {
            if (Product.Entity is IAuditableEntity entity)
            {
                entity.ModifiedOn = now;
            }
        }
    }
}
