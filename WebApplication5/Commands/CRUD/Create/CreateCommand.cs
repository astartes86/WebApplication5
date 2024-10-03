using MediatR;

namespace WebApplication5.Commands.CRUD.Create
{
    public class CreateCommand<TEntity> : IRequest<TEntity>

    {
        public CreateCommand()
        public TEntity Entity { get; set; }

        public CreateCommand(TEntity entity)
        {
            Entity = entity;
        }
    }
}
