using WebApplication5.Commands.CRUD.Update;
using FluentValidation;
using WebApplication5.Interfaces;

namespace WebApplication5.Validators.Entities
{
    public class UpdateValidator<TEntity> : AbstractValidator<UpdateCommand<TEntity>>
        where TEntity : IEntity
    {
        public UpdateValidator()
        {
            RuleFor(cmd => cmd.Entity.Id)
                .NotEmpty().WithMessage("Id is required.");
        }
    }
}
