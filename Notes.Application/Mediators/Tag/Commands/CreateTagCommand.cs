using MediatR;
using Notes.Domain.DTO.Tag;
using Notes.Domain.Result;

namespace Notes.Application.Mediators.Tag.Commands
{
    public class CreateTagCommand : IRequest<BaseResult<TagDTO>>
    {
        public CreateTagDTO DTO { get; set; }

        public CreateTagCommand(CreateTagDTO dto)
        {
            DTO = dto;
        }
    }
}
