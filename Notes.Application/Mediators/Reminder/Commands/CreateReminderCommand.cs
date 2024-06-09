using MediatR;
using Notes.Domain.DTO.Reminder;
using Notes.Domain.Result;

namespace Reminders.Application.Mediators.Reminder.Commands
{
    public class CreateReminderCommand : IRequest<BaseResult<ReminderDTO>>
    {
        public CreateReminderDTO DTO { get; set; }

        public CreateReminderCommand(CreateReminderDTO dto)
        {
            DTO = dto;
        }
    }
}
