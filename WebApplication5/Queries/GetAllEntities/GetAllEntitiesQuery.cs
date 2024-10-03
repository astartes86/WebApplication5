using WebApplication5.DAL;
using MediatR;
using WebApplication5.Interfaces;

namespace WebApplication5.Queries.GetAllEntities
{
    public class GetAllEntitiesQuery<TEntity> : IRequest<IEnumerable<TEntity>>
    {
    }
}
