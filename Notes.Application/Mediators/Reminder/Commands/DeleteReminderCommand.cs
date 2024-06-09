using MediatR;
using Notes.Domain.DTO.Reminder;
using Notes.Domain.Result;

namespace Reminders.Application.Mediators.Reminder.Commands
{
    public class DeleteReminderCommand : IRequest<BaseResult<ReminderDTO>>
    {
        public long Id { get; }

        public DeleteReminderCommand(long id)
        {
            Id = id;
        }
    }
}
