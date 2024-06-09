using AutoMapper;
using Notes.Domain.DTO.Note;
using Notes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Application.Mapping
{
    public class NoteMapping : Profile
    {
        public NoteMapping()
        {
            CreateMap<Note, NoteDTO>()
                .ForCtorParam(ctorParamName: "NoteId", m => m.MapFrom(s => s.NoteId))
                .ForCtorParam(ctorParamName: "Title", m => m.MapFrom(s => s.Title))
                .ForCtorParam(ctorParamName: "Text", m => m.MapFrom(s => s.Text))
                .ForCtorParam(ctorParamName: "Tags", m => m.MapFrom(s => s.Tags))
                .ReverseMap();
        }
    }
}
