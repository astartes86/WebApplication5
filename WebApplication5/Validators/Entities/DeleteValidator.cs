using FluentValidation;
using WebApplication5.Commands.CRUD.Delete;
using WebApplication5.Interfaces;

namespace WebApplication5.Validators.Entities
{
    public class DeleteValidator<TEntity> : AbstractValidator<DeleteCommand<TEntity>>
        where TEntity : IEntity
    {
        public DeleteValidator()
        {
            RuleFor(cmd => cmd.Entity.Id).NotEmpty().WithMessage("Id is required.")
                .GreaterThan(0).WithMessage("Id must be greater tehat 0.");
        }
    }
}
