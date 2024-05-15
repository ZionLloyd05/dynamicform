using AutoMapper.Internal;
using DynamicForm.Application.Implementations.Builders;
using DynamicForm.Application.Implementations.Services;
using DynamicForm.Application.Interfaces.Builders;
using DynamicForm.Application.Interfaces.Data;
using DynamicForm.Application.Interfaces.Services;
using DynamicForm.Application.MapProfile;
using DynamicForm.Application.Validations;
using DynamicForm.Infrastructure.DataAccess;
using FluentValidation;
using ApplicationFormBuilder = DynamicForm.Application.Implementations.Builders.ApplicationFormBuilder;
using IApplicationFormBuilder = DynamicForm.Application.Interfaces.Builders.IApplicationFormBuilder;

namespace DynamicForm.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services
                .AddValidatorsFromAssemblyContaining<FieldComponentValidator>();

            builder.Services.AddScoped<IRepository, Repository>();
            builder.Services.AddScoped<IApplicationFormBuilder, ApplicationFormBuilder>();
            builder.Services.AddScoped<IApplicationFormService, ApplicationFormService>();
            builder.Services.AddScoped<IFieldComponentBuilder, FieldComponentBuilder>();

            builder.Services.AddDbContext<DynamicFormDbContext>();

           var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}