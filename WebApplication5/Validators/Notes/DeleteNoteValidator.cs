using WebApplication5.Commands.Notes.DeleteNote;
using FluentValidation;
using WebApplication5.Interfaces;
using WebApplication5.DAL;

namespace WebApplication5.Validators.Notes
{
    public class DeleteNoteValidator : AbstractValidator<_GenericDeleteCommand<Note>>
    {
        public DeleteNoteValidator()
        {
            RuleFor(cmd => cmd.Id).NotEmpty().WithMessage("Id is required.")
                .GreaterThan(0).WithMessage("Id must be greater tehat 0.");
        }
    }
}
