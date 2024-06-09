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
    public class DeleteNoteCommand : IRequest<BaseResult<NoteDTO>>
    {
        public long Id { get; }

        public DeleteNoteCommand(long id)
        {
            Id = id;
        }
    }
}
