using WebApplication5.DAL;
using MediatR;

namespace WebApplication5.Queries.Notes.GetAllNotes
{
    public class GetAllNotesQuery:IRequest<IEnumerable<Note>>
    {
    }
}
