using MediatR;

namespace WebApplication5.Queries.GetEntity
{
    public class GetQuery<TEntity> : IRequest<TEntity>
    {
        //public int Id { get; set; }
        public TEntity Entity { get; set; }

        public GetQuery(TEntity entity)
        {
            Entity = entity;
        }
    }
}
