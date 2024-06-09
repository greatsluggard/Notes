using MediatR;
using Notes.Domain.DTO.Tag;
using Notes.Domain.Result;

namespace Notes.Application.Mediators.Tag.Queries
{
    public class GetTagsQuery : IRequest<CollectionResult<TagDTO>>
    {
    }
}
