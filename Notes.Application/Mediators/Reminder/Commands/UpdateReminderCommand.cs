using MediatR;
using Notes.Domain.DTO.Reminder;
using Notes.Domain.Result;

namespace Reminders.Application.Mediators.Reminder.Commands
{
    public class UpdateReminderCommand : IRequest<BaseResult<ReminderDTO>>
    {
        public UpdateReminderDTO DTO { get; set; }

        public UpdateReminderCommand(UpdateReminderDTO dto)
        {
            DTO = dto;
        }
    }
}
