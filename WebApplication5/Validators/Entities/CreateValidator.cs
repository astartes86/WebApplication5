using FluentValidation;
using WebApplication5.Commands.CRUD.Create;
using WebApplication5.Interfaces;

namespace WebApplication5.Validators.Entities
{
    public class CreateValidator<TEntity> : AbstractValidator<CreateCommand<TEntity>>
        where TEntity : IEntity
    {
        public CreateValidator()
        {
            RuleFor(cmd => cmd.Entity.Id)
                .NotEmpty().WithMessage("Id is required.");
        }
    }
}
