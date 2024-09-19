using FluentValidation;
using MediatR;
using WebApplication5.DAL;
using WebApplication5.Interfaces;

namespace WebApplication5.Commands.Notes.UpdateNote
{
    public class UpdateNoteHandler : IRequestHandler<UpdateNoteCommand, Note>
    {
        private readonly IRepository<Note> _noteRepository;
        private readonly IValidator<UpdateNoteCommand> _validator;

        public UpdateNoteHandler(IRepository<Note> noteRepository, IValidator<UpdateNoteCommand> validator)
        {
            _noteRepository = noteRepository;
            _validator = validator;
        }

        public async Task<Note> Handle(UpdateNoteCommand request, CancellationToken cancellationToken)
        {
            await _validator.ValidateAndThrowAsync(request);

            var note = new Note()
            {
                Header = request.Header,
                Text = request.Text
            };

            return await _noteRepository.Update(note);

        }
    }
}
