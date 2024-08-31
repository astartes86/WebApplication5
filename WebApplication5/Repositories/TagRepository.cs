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

        protected override DbSet<Tag> _dbSet => _dbContext.Tags;

    }
}
