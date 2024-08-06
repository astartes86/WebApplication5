using Microsoft.EntityFrameworkCore;
using WebApplication5.DAL;

namespace WebApplication5.Repositories
{
    public class NotesRepository : GenericRepository<MemoryDbContext, Note>
    {
        public NotesRepository(MemoryDbContext dbContext)
            : base(dbContext)
        {
        }


        protected override DbSet<Note> _dbSet => _dbContext.Notes;//задаем формат для БД так понимаю

    }
}
