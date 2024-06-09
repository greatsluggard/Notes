using MediatR;
using Notes.Application.Mediators.Tag.Queries;
using Notes.Application.Services;
using Notes.Domain.DTO.Tag;
using Notes.Domain.Result;

namespace Tags.Application.Mediators.Tag.Handlers
{
    public class GetTagByIdQueryHandler : IRequestHandler<GetTagByIdQuery, BaseResult<TagDTO>>
    {
        private readonly ITagService _tagService;

        public GetTagByIdQueryHandler(ITagService tagService)
        {
            _tagService = tagService;
        }

        public async Task<BaseResult<TagDTO>> Handle(GetTagByIdQuery request, CancellationToken cancellationToken)
        {
            return await _tagService.GetTagByIdAsync(request.Id);
        }
    }
}
