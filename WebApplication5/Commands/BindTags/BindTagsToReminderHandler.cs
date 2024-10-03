using FluentValidation;
using MediatR;
using WebApplication5.DAL;
using WebApplication5.Interfaces;

namespace WebApplication5.Commands.BindTags
{
    public class BindTagsToReminderHandler : IRequestHandler<BindTagsToReminderCommand, IEnumerable<ReminderTag>>
    {
        private readonly IAddRepository _noteAddRepository;
        private readonly IValidator<BindTagsToReminderCommand> _validator;

        public BindTagsToReminderHandler(IAddRepository addRepository, IValidator<BindTagsToReminderCommand> validator)
        {
            _validator = validator;
            _noteAddRepository = addRepository;
        }

        public async Task<IEnumerable<ReminderTag>> Handle(BindTagsToReminderCommand request, CancellationToken cancellationToken)
        {
            await _validator.ValidateAndThrowAsync(request);
            return await _noteAddRepository.BindReminder(request.ReminderId, request.TagsIds);
        }
    }
}
