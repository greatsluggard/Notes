using MediatR;
using Notes.Application.Mediators.Note.Queries;
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
    public class GetNotesQueryHandler : IRequestHandler<GetNotesQuery, CollectionResult<NoteDTO>>
    {
        private readonly INoteService _noteService;

        public GetNotesQueryHandler(INoteService noteService)
        {
            _noteService = noteService;
        }

        public async Task<CollectionResult<NoteDTO>> Handle(GetNotesQuery request, CancellationToken cancellationToken)
        {
            return await _noteService.GetNotesAsync();
        }
    }
}
