using WebApplication5.DAL;
using WebApplication5.Interfaces;
using MediatR;
using WebApplication5.Pagination;
using WebApplication5.Extensions;
using Azure;
using FluentAssertions.Equivalency;

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
            /*            var page = _repository.GetAll()
                                              .Paginate(request.Pageable);
                        return Task.FromResult((IEnumerable<TEntity>)page.Content);*/
            Pageable pageable = new ()
            {
                PageNumber = request.PageNumber,
                PageSize= request.PageSize

            };

            var page = await _repository.GetAll()
                             .PaginateAsync(pageable);
            return page.Content;
        }
    }
}
