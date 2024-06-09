using MediatR;
using Notes.Application.Mediators.Tag.Commands;
using Notes.Application.Services;
using Notes.Domain.DTO.Tag;
using Notes.Domain.Result;

namespace Notes.Application.Mediators.Tag.Handlers
{
    public class CreateTagCommandHandler : IRequestHandler<CreateTagCommand, BaseResult<TagDTO>>
    {
        private readonly ITagService _tagService;

        public CreateTagCommandHandler(ITagService tagService)
        {
            _tagService = tagService;
        }

        public async Task<BaseResult<TagDTO>> Handle(CreateTagCommand request, CancellationToken cancellationToken)
        {
            return await _tagService.CreateTagAsync(request.DTO);
        }
    }
}
