using FluentValidation;
using MediatR;
using WebApplication5.Interfaces;

namespace WebApplication5.Commands.CRUD.Delete
{
    public class DeleteHandler<TEntity> : IRequestHandler<DeleteCommand<TEntity>, TEntity>
        where TEntity : class, IEntity
    {
        private readonly IRepository<TEntity> _repository;
        private readonly IValidator<DeleteCommand<TEntity>> _validator;

        public DeleteHandler(IRepository<TEntity> repository, IValidator<DeleteCommand<TEntity>> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<TEntity> Handle(DeleteCommand<TEntity> request, CancellationToken cancellationToken)
        {
            await _validator.ValidateAndThrowAsync(request);

            return await _repository.Delete(request.Entity.Id);
        }
    }
}
