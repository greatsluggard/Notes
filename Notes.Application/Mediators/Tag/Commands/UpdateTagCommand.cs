using MediatR;
using Notes.Domain.DTO.Tag;
using Notes.Domain.Result;

namespace Notes.Application.Mediators.Tag.Commands
{
    public class UpdateTagCommand : IRequest<BaseResult<TagDTO>>
    {
        public UpdateTagDTO DTO { get; set; }

        public UpdateTagCommand(UpdateTagDTO dto)
        {
            DTO = dto;
        }
    }
}
