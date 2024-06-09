using MediatR;
using Notes.Application.Mediators.Note.Commands;
using Notes.Application.Services;
using Notes.Domain.DTO.Note;
using Notes.Domain.Result;

namespace Notes.Application.Mediators.Note.Handlers
{
    public class CreateNoteCommandHandler : IRequestHandler<CreateNoteCommand, BaseResult<NoteDTO>>
    {
        private readonly INoteService _noteService;

        public CreateNoteCommandHandler(INoteService noteService)
        {
            _noteService = noteService;
        }

        public async Task<BaseResult<NoteDTO>> Handle(CreateNoteCommand request, CancellationToken cancellationToken)
        {
            return await _noteService.CreateNoteAsync(request.DTO);
        }
    }
}
