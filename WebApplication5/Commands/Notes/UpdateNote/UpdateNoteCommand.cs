using WebApplication5.DAL;
using MediatR;

namespace WebApplication5.Commands.Notes.UpdateNote
{
    public class UpdateNoteCommand : IRequest<Note>
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public string Text { get; set; }
    }
}
