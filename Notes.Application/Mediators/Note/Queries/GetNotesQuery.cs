using MediatR;
using Notes.Domain.DTO.Note;
using Notes.Domain.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Application.Mediators.Note.Queries
{
    public class GetNotesQuery : IRequest<CollectionResult<NoteDTO>>
    {
    }
}
