using MediatR;
using Notes.Domain.DTO.Reminder;
using Notes.Domain.Result;

namespace Reminders.Application.Mediators.Reminder.Queries
{
    public class GetReminderByIdQuery : IRequest<BaseResult<ReminderDTO>>
    {
        public long Id { get; }

        public GetReminderByIdQuery(long id)
        {
            Id = id;
        }
    }
}
