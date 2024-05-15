using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

    public DbSet<ProgramForm> ProgramForms { get; set; } = default!;
    public DbSet<FieldComponent> FieldComponents { get; set; } = default!;
    public DbSet<FieldComponentValidation> FieldValidations { get; set; } = default!;
    public DbSet<FieldMetaData> FieldMetaData { get; set; } = default!;
}
