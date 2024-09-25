using FluentValidation;
using MediatR;
using WebApplication5.Interfaces;

namespace WebApplication5.Commands.CRUD.Create
{
    public class CreateHandler<TEntity> : IRequestHandler<CreateCommand<TEntity>, TEntity>
        where TEntity : class, IEntity
    {
        private readonly IRepository<TEntity> _repository;
        private readonly IValidator<CreateCommand<TEntity>> _validator;

        public CreateHandler(IRepository<TEntity> repository, IValidator<CreateCommand<TEntity>> validator)
        //public CreateNoteHandler(IRepository<Note> noteRepository)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<TEntity> Handle(CreateCommand<TEntity> request, CancellationToken cancellationToken)
        {
            await _validator.ValidateAndThrowAsync(request);

            // Фабричный метод для создания сущности
            var entity = CreateEntity(request);

            return await _repository.Add(entity);
        }


        private TEntity CreateEntity(CreateCommand<TEntity> request)
        {
            // Создаем экземпляр сущности и заполняем поля
            var entity = Activator.CreateInstance<TEntity>();

            // Заполняем поля сущности данными из запроса
            var properties = typeof(TEntity).GetProperties();
            foreach (var property in properties)
            {
                if (property.Name != "Id" && request.Entity.GetType().GetProperty(property.Name) != null)
                {
                    property.SetValue(entity, request.Entity.GetType().GetProperty(property.Name).GetValue(request.Entity));
                }
            }

            return entity;
        }
    }
}
