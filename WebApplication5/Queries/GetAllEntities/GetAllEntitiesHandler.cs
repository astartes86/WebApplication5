using WebApplication5.DAL;
using WebApplication5.Interfaces;
using MediatR;

namespace WebApplication5.Queries.GetAllEntities
{
    public class GetAllEntitiesHandler<TEntity> : IRequestHandler<GetAllEntitiesQuery<TEntity>, IEnumerable<TEntity>>
                where TEntity : class, IEntity
    {

        private readonly IRepository<TEntity> _repository;

        public GetAllEntitiesHandler(IRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<TEntity>> Handle(GetAllEntitiesQuery<TEntity> request, CancellationToken cancellationToken)
        {
            return await _repository.GetAll();
        }

    }
}
