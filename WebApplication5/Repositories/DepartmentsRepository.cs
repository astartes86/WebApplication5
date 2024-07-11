using Microsoft.EntityFrameworkCore;
using WebApplication5.DAL;

namespace WebApplication5.Repositories
{
    public class DepartmentsRepository : GenericRepository<MemoryDbContext, Department>
    {
        public DepartmentsRepository(MemoryDbContext dbContext)
            : base(dbContext)
        {
        }

        protected override DbSet<Department> DbSet => _dbContext.Departments;
    }
}
