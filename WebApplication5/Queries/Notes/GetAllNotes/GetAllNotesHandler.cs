using WebApplication5.DAL;
using WebApplication5.Interfaces;
using MediatR;

namespace WebApplication5.Queries.Notes.GetAllNotes
{
    public class GetAllNotesHandler : IRequestHandler<GetAllNotesQuery, IEnumerable<Note>>
    {

        private readonly IRepository<Note> _noteRepository;

        public GetAllNotesHandler(IRepository<Note> noteRepository)
        {
            _noteRepository = noteRepository;
        }

        public async Task<IEnumerable<Note>> Handle(GetAllNotesQuery request, CancellationToken cancellationToken)
        {
            return await _noteRepository.GetAll();
        }

    }
}
