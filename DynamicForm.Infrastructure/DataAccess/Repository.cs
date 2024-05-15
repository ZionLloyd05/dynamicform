using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicForm.Application.Interfaces.Data;
using DynamicForm.Domain.Models;

namespace DynamicForm.Infrastructure.DataAccess;

public class Repository : IRepository
{
    private readonly DynamicFormDbContext context;

    public Repository(DynamicFormDbContext context)
    {
        this.context = context;
    }

    public void AddApplicationForm(ApplicationForm applicationForm)
    {
        context.Add(applicationForm);
    }

    public async Task SaveApplicationFormAsync()
    {
        await context.SaveChangesAsync();
    }
}
