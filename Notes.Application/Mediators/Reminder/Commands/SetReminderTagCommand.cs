using MediatR;
using Notes.Domain.DTO.Reminder;
using Notes.Domain.Result;

namespace Reminders.Application.Mediators.Reminder.Commands
{
    public class SetReminderTagCommand : IRequest<BaseResult<ReminderDTO>>
    {
        public long Id { get; }
        public string Name { get; }

        public SetReminderTagCommand(long id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
