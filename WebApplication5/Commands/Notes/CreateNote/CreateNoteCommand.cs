using WebApplication5.DAL;
using MediatR;

namespace WebApplication5.Commands.Notes.CreateNote
{
    public class CreateNoteCommand : IRequest<Note>
    {
        public string Header { get; set; }
        public string Text { get; set; }

    }
}
