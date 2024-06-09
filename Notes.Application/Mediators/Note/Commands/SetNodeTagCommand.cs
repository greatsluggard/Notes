using MediatR;
using Notes.Domain.DTO.Note;
using Notes.Domain.Result;

namespace Notes.Application.Mediators.Note.Commands
{
    public class SetNodeTagCommand : IRequest<BaseResult<NoteDTO>>
    {
        public long Id { get; }
        public string Name { get; }

        public SetNodeTagCommand(long id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
