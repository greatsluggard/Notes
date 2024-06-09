using MediatR;
using Notes.Application.Mediators.Note.Commands;
using Notes.Application.Services;
using Notes.Domain.DTO.Note;
using Notes.Domain.Result;

namespace Notes.Application.Mediators.Note.Handlers
{
    public class SetNodeTagCommandHandler : IRequestHandler<SetNodeTagCommand, BaseResult<NoteDTO>>
    {
        private readonly INoteService _noteService;

        public SetNodeTagCommandHandler(INoteService noteService)
        {
            _noteService = noteService;
        }

        public async Task<BaseResult<NoteDTO>> Handle(SetNodeTagCommand request, CancellationToken cancellationToken)
        {
            return await _noteService.TagNote(request.Id, request.Name);
        }
    }
}
