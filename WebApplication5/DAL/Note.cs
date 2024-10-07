using FluentValidation;
using System.ComponentModel.DataAnnotations;
using WebApplication5.Commands.CRUD.Create;
using WebApplication5.Commands.CRUD.Delete;
using WebApplication5.Commands.CRUD.Update;
using WebApplication5.Interfaces;
using WebApplication5.Queries.GetEntity;

namespace WebApplication5.DAL
{
    public class Note : IEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Header { get; set; } = string.Empty;
        [Required]
        public string Text { get; set; } = string.Empty;
    }

    public class CreateValidatorNote<TEntity> : AbstractValidator<CreateCommand<TEntity>>
    where TEntity : Note
    {
        public CreateValidatorNote()
        {
            RuleFor(cmd => cmd.Entity.Header)
                .NotEmpty().WithMessage("Header is required.");
            RuleFor(cmd => cmd.Entity.Text)
                .NotEmpty().WithMessage("Text is required.");
        }
    }

    public class DeleteValidatorNote<TEntity> : AbstractValidator<DeleteCommand<TEntity>>
    where TEntity : Note
    {
        public DeleteValidatorNote()
        {
            RuleFor(cmd => cmd.Entity.Id).NotEmpty().WithMessage("Id is required.")
                .GreaterThan(0).WithMessage("Id must be greater than 0.");
        }
    }

    public class UpdateValidatorNote<TEntity> : AbstractValidator<UpdateCommand<TEntity>>
    where TEntity : Note
    {
        public UpdateValidatorNote()
        {
            RuleFor(cmd => cmd.Entity.Id)
                .NotEmpty().WithMessage("Id is required.");
            RuleFor(cmd => cmd.Entity.Header)
                .NotEmpty().WithMessage("Header is required.");
            RuleFor(cmd => cmd.Entity.Text)
                .NotEmpty().WithMessage("Text is required.");
        }
    }

    public class GetByIdValidatorNote<TEntity> : AbstractValidator<GetQuery<TEntity>>
            where TEntity : Note
    {
        public GetByIdValidatorNote()
        {
            RuleFor(query => query.Entity.Id).NotEmpty().WithMessage("Id is required.")
                .GreaterThan(0).WithMessage("Id must be greater than 0.");
        }
    }
}
