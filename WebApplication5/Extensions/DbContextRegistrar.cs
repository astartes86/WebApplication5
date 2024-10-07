using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebApplication5.Commands.CRUD.Create;
using WebApplication5.Commands.CRUD.Delete;
using WebApplication5.Commands.CRUD.Update;
using WebApplication5.DAL;
using WebApplication5.Interfaces;
using WebApplication5.Queries.GetAllEntities;
using WebApplication5.Queries.GetEntity;
using WebApplication5.Repositories;

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
            services.AddScoped(typeof(IRequestHandler<GetAllEntitiesQuery<Note>, IEnumerable<Note>>), typeof(GetAllEntitiesHandler<Note>));
            services.AddScoped(typeof(IRequestHandler<GetAllEntitiesQuery<Reminder>, IEnumerable<Reminder>>), typeof(GetAllEntitiesHandler<Reminder>));
            services.AddScoped(typeof(IRequestHandler<GetAllEntitiesQuery<Tag>, IEnumerable<Tag>>), typeof(GetAllEntitiesHandler<Tag>));

            services.AddScoped(typeof(IRequestHandler<GetQuery<Note>, Note>), typeof(GetHandler<Note>));
            services.AddScoped(typeof(IRequestHandler<GetQuery<Reminder>, Reminder>), typeof(GetHandler<Reminder>));
            services.AddScoped(typeof(IRequestHandler<GetQuery<Tag>, Tag>), typeof(GetHandler<Tag>));

            services.AddScoped(typeof(IRequestHandler<CreateCommand<Note>, Note>), typeof(CreateHandler<Note>));
            services.AddScoped(typeof(IRequestHandler<CreateCommand<Reminder>, Reminder>), typeof(CreateHandler<Reminder>));
            services.AddScoped(typeof(IRequestHandler<CreateCommand<Tag>, Tag>), typeof(CreateHandler<Tag>));

            services.AddScoped(typeof(IRequestHandler<UpdateCommand<Note>, Note>), typeof(UpdateHandler<Note>));
            services.AddScoped(typeof(IRequestHandler<UpdateCommand<Reminder>, Reminder>), typeof(UpdateHandler<Reminder>));
            services.AddScoped(typeof(IRequestHandler<UpdateCommand<Tag>, Tag>), typeof(UpdateHandler<Tag>));

            services.AddScoped(typeof(IRequestHandler<DeleteCommand<Note>, Note>), typeof(DeleteHandler<Note>));
            services.AddScoped(typeof(IRequestHandler<DeleteCommand<Reminder>, Reminder>), typeof(DeleteHandler<Reminder>));
            services.AddScoped(typeof(IRequestHandler<DeleteCommand<Tag>, Tag>), typeof(DeleteHandler<Tag>));


            // Регистрация обобщенного валидатора вручную
            services.AddScoped(typeof(IValidator<GetQuery<Note>>), typeof(GetByIdValidatorNote<Note>));
            services.AddScoped(typeof(IValidator<GetQuery<Reminder>>), typeof(GetByIdValidatorReminder<Reminder>));
            services.AddScoped(typeof(IValidator<GetQuery<Tag>>), typeof(GetByIdValidatorTag<Tag>));

            services.AddScoped(typeof(IValidator<DeleteCommand<Note>>), typeof(DeleteValidatorNote<Note>));
            services.AddScoped(typeof(IValidator<DeleteCommand<Reminder>>), typeof(DeleteValidatorReminder<Reminder>));
            services.AddScoped(typeof(IValidator<DeleteCommand<Tag>>), typeof(DeleteValidatorTag<Tag>));

            services.AddScoped(typeof(IValidator<UpdateCommand<Note>>), typeof(UpdateValidatorNote<Note>));
            services.AddScoped(typeof(IValidator<UpdateCommand<Reminder>>), typeof(UpdateValidatorReminder<Reminder>));
            services.AddScoped(typeof(IValidator<UpdateCommand<Tag>>), typeof(UpdateValidatorTag<Tag>));

 //           services.AddScoped(typeof(IValidator<CreateCommand<Note>>), typeof(CreateValidator<Note>));
            services.AddScoped(typeof(IValidator<CreateCommand<Note>>), typeof(CreateValidatorNote<Note>));
            services.AddScoped(typeof(IValidator<CreateCommand<Reminder>>), typeof(CreateValidatorReminder<Reminder>));
            services.AddScoped(typeof(IValidator<CreateCommand<Tag>>), typeof(CreateValidatorTag<Tag>));

            return services;
        }
    } 
}
