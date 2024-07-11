using WebApplication5.DAL;
using Microsoft.EntityFrameworkCore;
using WebApplication5.Interfaces;
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

            services.AddScoped<IRepository<Employee>, EmployeeRepository>();
            services.AddScoped<IRepository<Department>, DepartmentsRepository>();

            return services;
        }
    }
}
