using WebApplication5.Commands.Notes.CreateNote;
using FluentValidation;

namespace CQRSMediator.Validators.Notes
{
    public class CreateNoteValidator : AbstractValidator<CreateNoteCommand>
    {
        public CreateNoteValidator()
        {
            RuleFor(cmd => cmd.Text).NotEmpty().WithMessage("Text is required.");

            RuleFor(cmd => cmd.Header).NotEmpty().WithMessage("My Header is required.");                
        }
    }
}
