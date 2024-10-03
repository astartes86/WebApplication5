using MediatR;
using WebApplication5.DAL;
using WebApplication5.Interfaces;

namespace WebApplication5.Commands.CRUD.Update
{
    public class UpdateCommand<TEntity> : IRequest<TEntity>

    {
        public TEntity Entity { get; set; }

        public UpdateCommand(TEntity entity)
        {
            Entity = entity;
        }
    }
}
