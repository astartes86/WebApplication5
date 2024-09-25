using FluentValidation;
using MediatR;
using WebApplication5.Commands.CRUD.Create;
using WebApplication5.Interfaces;

namespace WebApplication5.Commands.CRUD.Update
{
    public class UpdateHandler<TEntity> : IRequestHandler<UpdateCommand<TEntity>, TEntity>
        where TEntity : class, IEntity
    {
        private readonly IRepository<TEntity> _repository;
        private readonly IValidator<UpdateCommand<TEntity>> _validator;

        public UpdateHandler(IRepository<TEntity> repository, IValidator<UpdateCommand<TEntity>> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<TEntity> Handle(UpdateCommand<TEntity> request, CancellationToken cancellationToken)
        {
            await _validator.ValidateAndThrowAsync(request);

            return await _repository.Update(request.Entity);

        }
    }
}
