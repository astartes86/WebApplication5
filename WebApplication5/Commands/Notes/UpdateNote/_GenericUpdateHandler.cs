using FluentValidation;
using MediatR;
using WebApplication5.DAL;
using WebApplication5.Interfaces;

namespace WebApplication5.Commands.Notes.UpdateNote
{
    public class _GenericUpdateHandler<TEntity> : IRequestHandler<UpdateCommand<TEntity>, TEntity>
        where TEntity : class, IEntity
    {
        private readonly IRepository<TEntity> _repository;
        private readonly IValidator<UpdateCommand<TEntity>> _validator;

        public _GenericUpdateHandler(IRepository<TEntity> repository, IValidator<UpdateCommand<TEntity>> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<TEntity> Handle(UpdateCommand<TEntity> request, CancellationToken cancellationToken)
        {
            await _validator.ValidateAndThrowAsync(request);

/*            TEntity note = new TEntity()
            {
                Id = request.Id, 
                Header = request.Header,
                Text = request.Text
            };*/

            return await _repository.Update(request.Entity);

        }
    }
}
