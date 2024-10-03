using FluentValidation;
using WebApplication5.Commands.BindTags;

namespace WebApplication5.Validators.Entities
{
    public class BindNoteValidator : AbstractValidator<BindTagsToNoteCommand>
    {
        public BindNoteValidator()
        {
            RuleFor(x => x.NoteId).NotEmpty().WithMessage("NoteId is required.");
            RuleFor(x => x.TagsIds)
                .NotEmpty().WithMessage("TagIds is required")
                .Must(x => x.All(tagId => tagId > 0)).WithMessage("TagIds must be greate than 0.");

        }
    }
}
