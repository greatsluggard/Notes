using MediatR;
using Notes.Domain.DTO.Tag;
using Notes.Domain.Result;

namespace Notes.Application.Mediators.Tag.Queries
{
    public class GetTagByIdQuery : IRequest<BaseResult<TagDTO>>
    {
        public long Id { get; }

        public GetTagByIdQuery(long id)
        {
            Id = id;
        }
    }
}
