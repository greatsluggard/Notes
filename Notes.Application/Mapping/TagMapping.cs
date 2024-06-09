using AutoMapper;
using Notes.Domain.DTO.Reminder;
using Notes.Domain.DTO.Tag;
using Notes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Application.Mapping
{
    public class TagMapping : Profile
    {
        public TagMapping()
        {
            CreateMap<Tag, TagDTO>()
                .ForCtorParam(ctorParamName: "TagId", m => m.MapFrom(s => s.TagId))
                .ForCtorParam(ctorParamName: "Name", m => m.MapFrom(s => s.Name));
        }
    }
}
