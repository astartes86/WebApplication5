using FluentValidation;
using MediatR;
using WebApplication5.DAL;
using WebApplication5.Interfaces;

namespace WebApplication5.Commands.BindTags
{
    public class BindTagsNoteReminderHandler : IRequestHandler<BindTagsNoteReminderCommand, Tag>
    {
        private readonly IAddRepository _noteAddRepository;
        private readonly IValidator<BindTagsNoteReminderCommand> _validator;

        public BindTagsNoteReminderHandler(IAddRepository addRepository, IValidator<BindTagsNoteReminderCommand> validator)
        {
            _validator = validator;
            _noteAddRepository = addRepository;
        }

        public async Task<Tag> Handle(BindTagsNoteReminderCommand request, CancellationToken cancellationToken)
        {
            await _validator.ValidateAndThrowAsync(request);
            return await _noteAddRepository.BindTag(request.TagId, request.NoteIds, request.ReminderIds);
        }
    }
}
