using DynamicForm.Abstractions;
using DynamicForm.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DynamicForm.Infrastructure.DataAccess;

public class DynamicFormDbContext : DbContext
{
    public DynamicFormDbContext()
    {
    }

    public DynamicFormDbContext(DbContextOptions<DynamicFormDbContext> options) : base(options)
    {
    }

    public DbSet<Form> Forms { get; set; } = default!;
    public DbSet<FieldComponent> FieldComponents { get; set; } = default!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseCosmos(
            accountEndpoint: "https://localhost:8081",
            accountKey: "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==",
            databaseName: "form-db");
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
