using WebApplication5.Commands.Notes.UpdateNote;
using FluentValidation;

namespace WebApplication5.Validators.Notes
{
    public class UpdateNoteValidator : AbstractValidator<UpdateNoteCommand>
    {
        public UpdateNoteValidator()
        {
            RuleFor(cmd => cmd.Id)
                .NotEmpty().WithMessage("Id is required.");

            RuleFor(cmd => cmd.Text)
                .NotEmpty().WithMessage("Text is required.");

            RuleFor(cmd => cmd.Header)
                .NotEmpty().WithMessage("Title is required.");            
        }
    }
}
