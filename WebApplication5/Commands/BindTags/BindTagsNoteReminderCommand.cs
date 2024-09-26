using WebApplication5.DAL;
using MediatR;

namespace WebApplication5.Commands.BindTags
{
    public class BindTagsNoteReminderCommand : IRequest<Tag>
    {
        public int TagId { get; set; }

        public IEnumerable<int> NoteIds { get; set; }

        public IEnumerable<int> ReminderIds { get; set; }
    }
}
