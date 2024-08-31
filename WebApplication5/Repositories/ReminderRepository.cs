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

        protected override DbSet<Reminder> _dbSet => _dbContext.Reminders;


    }
}
