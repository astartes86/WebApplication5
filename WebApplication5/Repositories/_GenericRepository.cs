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
            try
            {
                await _dbContext.SaveChangesAsync();//гарантируем сохранность данных потому что  add добавляет новую сущность в контекст данных
            }
            catch (Exception ex)
            {
                Console.WriteLine("!!!не хочет сохранить!!!");

                if (ex.InnerException != null)
                {
                    Console.WriteLine("Inner Exception: " + ex.InnerException.Message);
                }
            }
            return entity;
            }


            public async Task<TEntity> Update(TEntity entity)
            {

            if (_dbContext.Set<TEntity>().Any(e => e.Id == entity.Id))
            {
                    _dbContext.Update(entity);
                    _dbContext.SaveChangesAsync();

                    return entity;
                }
            throw new ArgumentException("No such id in base");
            }

            public async Task <TEntity> Delete(int id)
            {
            var entity = await _dbSet.FirstOrDefaultAsync(x => x.Id == id);

            if (entity != null)
                {
                    _dbSet.Remove(entity);
                    await _dbContext.SaveChangesAsync();
                    return entity;
                }
            return null;
            }


            public async Task <IEnumerable<TEntity>> GetAll()
            {
                return await _dbSet.ToListAsync();
            }

         
            public async Task<TEntity?> GetById(int id) => await _dbSet.FirstOrDefaultAsync(x => x.Id == id);//интересно получилось записать
        /*  {
             return _dbSet.FirstOrDefault(x => x.Id == id);
            }*/
    }
}
