﻿namespace WebApplication5.Interfaces
{
    public interface IRepository<TEntity> where TEntity : IEntity
    {
        Task<TEntity> Add(TEntity entity);
        Task<TEntity> Update(int id, TEntity entity);
        Task<TEntity> Delete(TEntity entity);
        Task<IEnumerable<TEntity>> GetAll();
        TEntity? GetById(int id);// не определяю в задачу чтобы использовать еще и при удалении
    }
}
