using MediatR;

namespace WebApplication5.Commands.CRUD.Delete
{
    public class DeleteCommand<TEntity> : IRequest<TEntity>

    {
        public TEntity Entity { get; set; }

        public DeleteCommand(TEntity entity)
        {
            Entity = entity;
        }
    }
}
