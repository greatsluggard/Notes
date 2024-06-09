using MediatR;
using Notes.Application.Services;
using Notes.Domain.DTO.Reminder;
using Notes.Domain.Result;
using Reminders.Application.Mediators.Reminder.Commands;

namespace Reminders.Application.Mediators.Reminder.Handlers
{
    public class CreateReminderCommandHandler : IRequestHandler<CreateReminderCommand, BaseResult<ReminderDTO>>
    {
        private readonly IReminderService _reminderService;

        public CreateReminderCommandHandler(IReminderService reminderService)
        {
            _reminderService = reminderService;
        }

        public async Task<BaseResult<ReminderDTO>> Handle(CreateReminderCommand request, CancellationToken cancellationToken)
        {
            return await _reminderService.CreateReminderAsync(request.DTO);
        }
    }
}
