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

<<<<<<< HEAD
        protected override DbSet<Note> _dbSet => _dbContext.Notes;//задаем формат для БД так понимаю
=======
        protected override DbSet<Note> DbSet => _dbContext.Notes;
>>>>>>> 9731f92 (добавил свои сущности, протестил их свагером. остается удалить исходные. или мож оставлю пока.)
    }
}
