using Microsoft.EntityFrameworkCore;
using WebApplication5.DAL;

namespace WebApplication5.Repositories
{
    public class TagRepository : GenericRepository<MemoryDbContext, Tag>
    {
        public TagRepository(MemoryDbContext dbContext)
            : base(dbContext)
        {
        }

<<<<<<< HEAD
        protected override DbSet<Tag> _dbSet => _dbContext.Tags;
=======
        protected override DbSet<Tag> DbSet => _dbContext.Tags;
>>>>>>> 9731f92 (добавил свои сущности, протестил их свагером. остается удалить исходные. или мож оставлю пока.)
    }
}
