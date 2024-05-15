using DynamicForm.Application.Implementations.Builders;
using DynamicForm.Application.Implementations.Services;
using DynamicForm.Application.Interfaces.Builders;
using DynamicForm.Application.Interfaces.Services;
using DynamicForm.Application.Validations;
using FluentValidation;
using ApplicationBuilder = DynamicForm.Application.Implementations.Builders.ApplicationBuilder;
using IApplicationBuilder = DynamicForm.Application.Interfaces.Builders.IApplicationBuilder;

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

            builder.Services.AddScoped<IApplicationBuilder, ApplicationBuilder>();
            builder.Services.AddScoped<IApplicationService, ApplicationService>();
            builder.Services.AddScoped<IFieldComponentBuilder, FieldComponentBuilder>();
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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