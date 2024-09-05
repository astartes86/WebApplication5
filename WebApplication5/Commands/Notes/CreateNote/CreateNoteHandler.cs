using WebApplication5.DAL;
using WebApplication5.Interfaces;
//using FluentValidation;
using MediatR;

namespace WebApplication5.Commands.Notes.CreateNote
{
    public class CreateNoteHandler : IRequestHandler<CreateNoteCommand, Note>
    {
        private readonly IRepository<Note> _noteRepository;
        //private readonly IValidator<CreateNoteCommand> _validator;

        public CreateNoteHandler(IRepository<Note> noteRepository)
        {
            _noteRepository = noteRepository;
            //_validator = validator;
        }

        public async Task<Note> Handle(CreateNoteCommand request, CancellationToken cancellationToken)
        {
            //await _validator.ValidateAndThrowAsync(request);

            var note = new Note()
            {
                Header = request.Header,
                Text = request.Text
            };

            return await _noteRepository.Add(note);
        }

    }
}
