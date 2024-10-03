using WebApplication5.DAL;
using MediatR;

namespace WebApplication5.Commands.BindTags
{
    public class BindTagsToReminderCommand : IRequest<IEnumerable<ReminderTag>?>
    {
        public int ReminderId { get; set; }

        public IEnumerable<int> TagsIds { get; set; }
    }
}
