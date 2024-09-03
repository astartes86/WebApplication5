using WebApplication5.DAL;
using MediatR;

namespace CQRSMediator.Queries.Notes.GetAllNotes
{
    public class GetAllNotesQuery:IRequest<IEnumerable<Note>>
    {
    }
}
