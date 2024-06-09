using MediatR;
using Notes.Application.Mediators.Tag.Queries;
using Notes.Application.Services;
using Notes.Domain.DTO.Tag;
using Notes.Domain.Result;

namespace Tags.Application.Mediators.Tag.Handlers
{
    public class GetTagsQueryHandler : IRequestHandler<GetTagsQuery, CollectionResult<TagDTO>>
    {
        private readonly ITagService _tagService;

        public GetTagsQueryHandler(ITagService tagService)
        {
            _tagService = tagService;
        }

        public async Task<CollectionResult<TagDTO>> Handle(GetTagsQuery request, CancellationToken cancellationToken)
        {
            return await _tagService.GetTagsAsync();
        }
    }
}
