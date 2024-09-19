using FluentValidation;
using MediatR;
using WebApplication5.DAL;
using WebApplication5.Interfaces;

namespace WebApplication5.Commands.Notes.DeleteNote
{
    public class DeleteNoteHandler : IRequestHandler<_GenericDeleteCommand<Note>, int?>
    {
        private readonly IRepository<Note> _noteRepository;
        private readonly IValidator<_GenericDeleteCommand<Note>> _validator;

        public DeleteNoteHandler(IRepository<Note> noteRepository, IValidator<_GenericDeleteCommand<Note>> validator)
        {
            _noteRepository = noteRepository;
            _validator = validator;
        }

        public async Task<int?> Handle(_GenericDeleteCommand<Note> request, CancellationToken cancellationToken)
        {
            await _validator.ValidateAndThrowAsync(request);

            return await _noteRepository.Delete(request.Id);
        }
    }
}
