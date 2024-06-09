using MediatR;
using Notes.Domain.DTO.Note;
using Notes.Domain.Result;

namespace Notes.Application.Mediators.Note.Queries
{
    public class GetNoteByIdQuery : IRequest<BaseResult<NoteDTO>>
    {
        public long Id { get; }

        public GetNoteByIdQuery(long id)
        {
            Id = id;
        }
    }
}
