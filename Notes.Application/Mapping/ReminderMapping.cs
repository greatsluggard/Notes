using AutoMapper;
using Notes.Domain.DTO.Reminder;
using Notes.Domain.Entities;

namespace Notes.Application.Mapping
{
    public class ReminderMapping : Profile
    {
        public ReminderMapping()
        {
            CreateMap<Reminder, ReminderDTO>()
                .ForCtorParam(ctorParamName: "ReminderId", m => m.MapFrom(s => s.ReminderId))
                .ForCtorParam(ctorParamName: "Title", m => m.MapFrom(s => s.Title))
                .ForCtorParam(ctorParamName: "Text", m => m.MapFrom(s => s.Text))
                .ForCtorParam(ctorParamName: "ReminderTime", m => m.MapFrom(s => s.ReminderTime))
                .ForCtorParam(ctorParamName: "Tags", m => m.MapFrom(s => s.Tags))
                .ReverseMap();
        }
    }
}
