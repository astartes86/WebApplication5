using FluentValidation;
using WebApplication5.Commands.CRUD.Create;
using WebApplication5.Commands.CRUD.Delete;
using WebApplication5.Commands.CRUD.Update;
using WebApplication5.Interfaces;
using WebApplication5.Queries.GetEntity;

namespace WebApplication5.DAL
{
    public class Tag : IEntity
    {   
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
    }

    public class CreateValidatorTag<TEntity> : AbstractValidator<CreateCommand<TEntity>>
    where TEntity : Tag
    {
        public CreateValidatorTag()
        {
            RuleFor(cmd => cmd.Entity.Name)
                .NotEmpty().WithMessage("Name is required.");
        }
    }

    public class DeleteValidatorTag<TEntity> : AbstractValidator<DeleteCommand<TEntity>>
    where TEntity : Tag
    {
        public DeleteValidatorTag()
        {
            RuleFor(cmd => cmd.Entity.Id).NotEmpty().WithMessage("Id is required.")
                .GreaterThan(0).WithMessage("Id must be greater than 0.");
        }
    }

    public class UpdateValidatorTag<TEntity> : AbstractValidator<UpdateCommand<TEntity>>
    where TEntity : Tag
    {
        public UpdateValidatorTag()
        {
            RuleFor(cmd => cmd.Entity.Id)
                .NotEmpty().WithMessage("Id is required.");
            RuleFor(cmd => cmd.Entity.Name)
                .NotEmpty().WithMessage("Name is required.");
        }
    }

    public class GetByIdValidatorTag<TEntity> : AbstractValidator<GetQuery<TEntity>>
        where TEntity : Tag
    {
        public GetByIdValidatorTag()
        {
            RuleFor(query => query.Entity.Id).NotEmpty().WithMessage("Id is required.")
                .GreaterThan(0).WithMessage("Id must be greater than 0.");
        }
    }
}
