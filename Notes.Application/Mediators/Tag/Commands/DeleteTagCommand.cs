using MediatR;
using Notes.Domain.DTO.Tag;
using Notes.Domain.Result;

namespace Notes.Application.Mediators.Tag.Commands
{
    public class DeleteTagCommand : IRequest<BaseResult<TagDTO>>
    {
        public long Id { get; }

        public DeleteTagCommand(long id)
        {
            Id = id;
        }
    }
}
