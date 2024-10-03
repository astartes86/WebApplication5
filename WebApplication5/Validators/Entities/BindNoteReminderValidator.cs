using FluentValidation;
using WebApplication5.Commands.BindTags;

namespace WebApplication5.Validators.Entities
{
    public class BindNoteReminderValidator : AbstractValidator<BindTagsNoteReminderCommand>
    {
        public BindNoteReminderValidator()
        {
            RuleFor(x => x.TagId).NotEmpty().WithMessage("NoteId is required.");
            RuleFor(x => x.NoteIds)
                .NotEmpty().WithMessage("NoteIds is required")
                .Must(x => x.All(tagId => tagId > 0)).WithMessage("TagIds must be greate than 0.");
            RuleFor(x => x.ReminderIds)
                .NotEmpty().WithMessage("ReminderIds is required")
                .Must(x => x.All(tagId => tagId > 0)).WithMessage("TagIds must be greate than 0.");
        }
    }
}
