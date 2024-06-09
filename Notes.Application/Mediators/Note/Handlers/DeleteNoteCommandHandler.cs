using MediatR;
using Notes.Application.Mediators.Note.Commands;
using Notes.Application.Services;
using Notes.Domain.DTO.Note;
using Notes.Domain.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Application.Mediators.Note.Handlers
{
    public class DeleteNoteCommandHandler : IRequestHandler<DeleteNoteCommand, BaseResult<NoteDTO>>
    {
        private readonly INoteService _noteService;

        public DeleteNoteCommandHandler(INoteService noteService)
        {
            _noteService = noteService;
        }

        public async Task<BaseResult<NoteDTO>> Handle(DeleteNoteCommand request, CancellationToken cancellationToken)
        {
            return await _noteService.DeleteNoteAsync(request.Id);
        }
    }
}
