using FluentValidation;
using MediatR;
using WebApplication5.DAL;
using WebApplication5.Interfaces;

namespace WebApplication5.Commands.BindTags
{
    public class BindTagsToNoteHandler : IRequestHandler<BindTagsToNoteCommand, IEnumerable<NoteTag>>
    {
        private readonly IAddRepository _noteAddRepository;
        private readonly IValidator<BindTagsToNoteCommand> _validator;

        public BindTagsToNoteHandler(IAddRepository addRepository, IValidator<BindTagsToNoteCommand> validator)
        {
            _validator = validator;
            _noteAddRepository = addRepository;
        }

        public async Task<IEnumerable<NoteTag>> Handle(BindTagsToNoteCommand request, CancellationToken cancellationToken)
        {
            await _validator.ValidateAndThrowAsync(request);
            return await _noteAddRepository.BindNote(request.NoteId, request.TagsIds);
        }
    }
}
