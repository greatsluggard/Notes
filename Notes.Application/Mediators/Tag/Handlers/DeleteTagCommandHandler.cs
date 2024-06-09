using MediatR;
using Notes.Application.Mediators.Tag.Commands;
using Notes.Application.Services;
using Notes.Domain.DTO.Tag;
using Notes.Domain.Result;

namespace Notes.Application.Mediators.Tag.Handlers
{
    public class DeleteTagCommandHandler : IRequestHandler<DeleteTagCommand, BaseResult<TagDTO>>
    {
        private readonly ITagService _tagService;

        public DeleteTagCommandHandler(ITagService tagService)
        {
            _tagService = tagService;
        }

        public async Task<BaseResult<TagDTO>> Handle(DeleteTagCommand request, CancellationToken cancellationToken)
        {
            return await _tagService.DeleteTagAsync(request.Id);
        }
    }
}
