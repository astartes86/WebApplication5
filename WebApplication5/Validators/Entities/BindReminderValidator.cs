using FluentValidation;
using WebApplication5.Commands.BindTags;

namespace WebApplication5.Validators.Entities
{
    public class BindReminderValidator : AbstractValidator<BindTagsToReminderCommand>
    {
        public BindReminderValidator()
        {
            RuleFor(x => x.ReminderId).NotEmpty().WithMessage("NoteId is required.");
            RuleFor(x => x.TagsIds)
                .NotEmpty().WithMessage("TagIds is required")
                .Must(x => x.All(tagId => tagId > 0)).WithMessage("TagIds must be greate than 0.");

        }
    }
}
