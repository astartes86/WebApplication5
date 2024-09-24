using MediatR;


namespace WebApplication5.Commands.Notes.UpdateNote
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
