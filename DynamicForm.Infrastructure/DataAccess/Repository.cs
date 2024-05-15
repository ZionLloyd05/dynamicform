using DynamicForm.Application.Interfaces.Data;
using DynamicForm.Domain.Models;
using Microsoft.EntityFrameworkCore;

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

    public async Task<IEnumerable<ApplicationForm>> RetrieveApplications()
    {
        var applications = await context.ApplicationForms.Include(
                                fm => fm.Questions)
                            .ThenInclude(fm => fm.QuestionMetaData)
                        .ToListAsync();

        return applications;
    }

    public async Task SaveApplicationFormAsync()
    {
        await context.SaveChangesAsync();
    }

    public async Task<ApplicationForm?> GetApplicationAsync(string Id)
    {
        return await context.ApplicationForms.Where(form => form.Id == Id)
            .SingleOrDefaultAsync();
    }

    public void UpdateApplicationForm(ApplicationForm applicationForm)
    {
        context.Update(applicationForm);
    }
}
