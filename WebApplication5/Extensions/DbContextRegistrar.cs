using WebApplication5.DAL;
using Microsoft.EntityFrameworkCore;
using WebApplication5.Interfaces;
using WebApplication5.Repositories;
using MediatR;
using WebApplication5.Commands.Notes.UpdateNote;
using FluentValidation;
using WebApplication5.Validators.Notes;

namespace WebApplication5.Extensions
{
    public static class DbContextRegistrar
    {
        private const string ConnectionStringName = "MemoryDB";

        public static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString(ConnectionStringName);

            services.AddDbContext<MemoryDbContext>(opts => opts.UseSqlServer(connectionString));


            services.AddScoped<IRepository<Note>, NotesRepository>();//Для разрешения фреймворка внедрения зависимостей
                                                                     //IRepository сначала он должен быть зарегистрирован в контейнере.
            services.AddScoped<IRepository<Reminder>, ReminderRepository>();
            services.AddScoped<IRepository<Tag>, TagRepository>();

            services.AddScoped<IAddRepository, LinksRepository<MemoryDbContext>>();

            // Регистрация обобщенного обработчика
            services.AddScoped(typeof(IRequestHandler<UpdateCommand<Note>, Note>), typeof(_GenericUpdateHandler<Note>));
            services.AddScoped(typeof(IRequestHandler<UpdateCommand<Reminder>, Reminder>), typeof(_GenericUpdateHandler<Reminder>));
            services.AddScoped(typeof(IRequestHandler<UpdateCommand<Tag>, Tag>), typeof(_GenericUpdateHandler<Tag>));
            // Регистрация обобщенного валидатора вручную
            services.AddScoped(typeof(IValidator<UpdateCommand<Note>>), typeof(UpdateValidator<Note>));
            services.AddScoped(typeof(IValidator<UpdateCommand<Reminder>>), typeof(UpdateValidator<Reminder>));
            services.AddScoped(typeof(IValidator<UpdateCommand<Tag>>), typeof(UpdateValidator<Tag>));

            return services;
        }
    } 
}
