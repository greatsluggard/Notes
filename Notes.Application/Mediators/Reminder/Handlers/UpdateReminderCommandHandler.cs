using MediatR;
using Notes.Application.Services;
using Notes.Domain.DTO.Reminder;
using Notes.Domain.Result;
using Reminders.Application.Mediators.Reminder.Commands;

namespace Reminders.Application.Mediators.Reminder.Handlers
{
    public class UpdateReminderCommandHandler : IRequestHandler<UpdateReminderCommand, BaseResult<ReminderDTO>>
    {
        private readonly IReminderService _reminderService;

        public UpdateReminderCommandHandler(IReminderService reminderService)
        {
            _reminderService = reminderService;
        }

        public async Task<BaseResult<ReminderDTO>> Handle(UpdateReminderCommand request, CancellationToken cancellationToken)
        {
            return await _reminderService.UpdateReminderAsync(request.DTO);
        }
    }
}
