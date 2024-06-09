using MediatR;
using Notes.Application.Mediators.Note.Queries;
using Notes.Application.Services;
using Notes.Domain.DTO.Note;
using Notes.Domain.Result;

namespace Notes.Application.Mediators.Note.Handlers
{
    public class GetNoteByIdQueryHandler : IRequestHandler<GetNoteByIdQuery, BaseResult<NoteDTO>>
    {
        private readonly INoteService _noteService;

        public GetNoteByIdQueryHandler(INoteService noteService)
        {
            _noteService = noteService;
        }

        public async Task<BaseResult<NoteDTO>> Handle(GetNoteByIdQuery request, CancellationToken cancellationToken)
        {
            return await _noteService.GetNoteByIdAsync(request.Id);
        }
    }
}
