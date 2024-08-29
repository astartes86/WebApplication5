using Microsoft.EntityFrameworkCore;
using WebApplication5.Interfaces;

namespace WebApplication5.Repositories
{
        public abstract class GenericRepository<TDbContext, TEntity> : IRepository<TEntity>
            where TDbContext : DbContext
            where TEntity : class, IEntity
    {
            protected readonly TDbContext _dbContext;

            protected abstract DbSet<TEntity> _dbSet { get; }

            protected GenericRepository(TDbContext dbContext)
            {
                _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            }





           public async Task<TEntity> Add(TEntity? entity)
            {
                await _dbSet.AddAsync(entity);

                await _dbContext.SaveChangesAsync();//гарантируем сохранность данных потому что  add добавляет новую сущность в контекст данных

                return entity;
            }





            public async Task<TEntity> Update(TEntity entity)
            {
                _dbSet.Update(entity);

                _dbContext.SaveChangesAsync();

                return entity;
        }





            public async Task<TEntity> Delete(TEntity entity)
            {
                _dbSet.Remove(entity);

                await _dbContext.SaveChangesAsync();

            return entity;
            }





            public async Task <IEnumerable<TEntity>> GetAll()
            {
                //var notes = await _dbSet.ToListAsync();
                return _dbSet;
        }





            public async Task <TEntity?> GetById(int id)
            {
                return _dbSet.FirstOrDefault(x => x.Id == id);
            }












    }
}
