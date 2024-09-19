using WebApplication5.DAL;
using MediatR;

namespace WebApplication5.Commands.Notes.BindTags
{
    public class BindTagsToNoteCommand : IRequest<IEnumerable<NoteTag>?>
    {
        public int NoteId { get; set; }

        public IEnumerable<int> TagsIds { get; set; }
    }
}
