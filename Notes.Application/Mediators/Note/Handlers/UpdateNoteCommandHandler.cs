using MediatR;
using Notes.Application.Mediators.Note.Commands;
using Notes.Application.Services;
using Notes.Domain.DTO.Note;
using Notes.Domain.Result;

namespace Notes.Application.Mediators.Note.Handlers
{
    public class UpdateNoteCommandHandler : IRequestHandler<UpdateNoteCommand, BaseResult<NoteDTO>>
    {
        private readonly INoteService _noteService;

        public UpdateNoteCommandHandler(INoteService noteService)
        {
            _noteService = noteService;
        }

        public async Task<BaseResult<NoteDTO>> Handle(UpdateNoteCommand request, CancellationToken cancellationToken)
        {
            return await _noteService.UpdateNoteAsync(request.DTO);
        }
    }
}
