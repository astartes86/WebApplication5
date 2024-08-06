using Microsoft.EntityFrameworkCore;
using WebApplication5.DAL;

namespace WebApplication5.Repositories
{
    public class ReminderRepository : GenericRepository<MemoryDbContext, Reminder>
    {
        public ReminderRepository(MemoryDbContext dbContext)
            : base(dbContext)
        {
        }

<<<<<<< HEAD
        protected override DbSet<Reminder> _dbSet => _dbContext.Reminders;
=======
        protected override DbSet<Reminder> DbSet => _dbContext.Reminders;
>>>>>>> 9731f92 (добавил свои сущности, протестил их свагером. остается удалить исходные. или мож оставлю пока.)
    }
}
