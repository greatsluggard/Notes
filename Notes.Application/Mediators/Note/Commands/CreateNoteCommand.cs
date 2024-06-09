using MediatR;
using Notes.Domain.DTO.Note;
using Notes.Domain.Result;

namespace Notes.Application.Mediators.Note.Commands
{
    public class CreateNoteCommand : IRequest<BaseResult<NoteDTO>>
    {
        public CreateNoteDTO DTO { get; set; }

        public CreateNoteCommand(CreateNoteDTO dto)
        {
            DTO = dto;
        }
    }
}
