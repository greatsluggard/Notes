using MediatR;
using Notes.Application.Mediators.Tag.Commands;
using Notes.Application.Services;
using Notes.Domain.DTO.Tag;
using Notes.Domain.Result;

namespace Tags.Application.Mediators.Tag.Handlers
{
    public class UpdateTagCommandHandler : IRequestHandler<UpdateTagCommand, BaseResult<TagDTO>>
    {
        private readonly ITagService _tagService;

        public UpdateTagCommandHandler(ITagService tagService)
        {
            _tagService = tagService;
        }

        public async Task<BaseResult<TagDTO>> Handle(UpdateTagCommand request, CancellationToken cancellationToken)
        {
            return await _tagService.UpdateTagAsync(request.DTO);
        }
    }
}
