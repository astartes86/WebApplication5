using WebApplication5.Commands.Notes.UpdateNote;
using FluentValidation;
using WebApplication5.Interfaces;

namespace WebApplication5.Validators.Notes
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
