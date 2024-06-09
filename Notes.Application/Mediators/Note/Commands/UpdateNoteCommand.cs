using MediatR;
using Notes.Domain.DTO.Note;
using Notes.Domain.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Application.Mediators.Note.Commands
{
    public class UpdateNoteCommand : IRequest<BaseResult<NoteDTO>>
    {
        public UpdateNoteDTO DTO { get; set; }

        public UpdateNoteCommand(UpdateNoteDTO dto)
        {
            DTO = dto;
        }
    }
}
