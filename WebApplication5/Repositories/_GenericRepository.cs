using Microsoft.EntityFrameworkCore;
using WebApplication5.Interfaces;

namespace WebApplication5.Repositories
{
        public abstract class GenericRepository<TDbContext, TEntity> : IRepository<TEntity>
            where TDbContext : DbContext
            where TEntity : class, IEntity
        {
            protected readonly TDbContext _dbContext;

            protected abstract DbSet<TEntity> DbSet { get; }

            public TEntity Add(TEntity entity)
            {
                DbSet.Add(entity);

                _dbContext.SaveChanges();

                return entity;
            }

            public TEntity Update(int id, TEntity entity)
            {
                DbSet.Update(entity);

                _dbContext.SaveChanges();

                return entity;
            }

            public void Delete(TEntity entity)
            {
                DbSet.Remove(entity);

                _dbContext.SaveChanges();
            }

            public virtual IQueryable<TEntity> GetAll()
            {
                return DbSet;
            }

            public virtual TEntity? GetById(int id)
            {
                return DbSet.FirstOrDefault(x => x.Id == id);
            }

            protected GenericRepository(TDbContext dbContext)
            {
                _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            }
        }
}
