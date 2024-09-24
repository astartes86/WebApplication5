using WebApplication5.DAL;
using WebApplication5.Extensions;
using WebApplication5.Interfaces;
using WebApplication5.Middleware;
using WebApplication5.Repositories;
using FluentValidation.AspNetCore;
using FluentValidation;
using System.Reflection;

namespace WebApplication5
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var services = builder.Services;
            var configuration = builder.Configuration;

            // Add services to the container.
            //services.AddAuthorization();

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddFluentValidationAutoValidation();
             

            services.AddDbContext(configuration); // подключение DB контекста
            services.AddControllers();


            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

               var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthorization();
            app.UseMiddleware<ErrorHandlerMiddleware>();
            app.MapControllers();
            //app.MapDefaultControllerRoute();
            //app.MapGet("/", () => $"Имя рабочего процесса: {System.Диагностика.Процесс.GetCurrentProcess().ProcessName}");
            app.Run();
        }
    }
}