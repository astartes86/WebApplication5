using Microsoft.EntityFrameworkCore;
using WebApplication5.DAL;

namespace WebApplication5.Repositories
{
        public class EmployeeRepository : GenericRepository<MemoryDbContext, Employee>
        {
            public EmployeeRepository(MemoryDbContext dbContext)
                : base(dbContext)
            {
            }

            protected override DbSet<Employee> DbSet => _dbContext.Employees;
        }
}
