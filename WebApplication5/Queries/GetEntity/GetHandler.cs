using FluentValidation;
using MediatR;
using WebApplication5.Interfaces;

namespace WebApplication5.Queries.GetEntity
{
    public class GetHandler<TEntity> : IRequestHandler<GetQuery<TEntity>, TEntity?>
                        where TEntity : class, IEntity
    {
        private readonly IRepository<TEntity> repository;
        private readonly IValidator<GetQuery<TEntity>> _validator;

        public GetHandler(IRepository<TEntity> noteRepository, IValidator<GetQuery<TEntity>> validator)
        {
            repository = noteRepository;
            _validator = validator;
        }

        public async Task<TEntity?> Handle(GetQuery<TEntity> request, CancellationToken cancellationToken)
        {
            await _validator.ValidateAndThrowAsync(request);
            return await repository.GetById(request.Entity.Id);
        }
    }
}
