using MediatR;
using Notes.Application.Services;
using Notes.Domain.DTO.Reminder;
using Notes.Domain.Result;
using Reminders.Application.Mediators.Reminder.Commands;

namespace Reminders.Application.Mediators.Reminder.Handlers
{
    public class DeleteReminderCommandHandler : IRequestHandler<DeleteReminderCommand, BaseResult<ReminderDTO>>
    {
        private readonly IReminderService _reminderService;

        public DeleteReminderCommandHandler(IReminderService reminderService)
        {
            _reminderService = reminderService;
        }

        public async Task<BaseResult<ReminderDTO>> Handle(DeleteReminderCommand request, CancellationToken cancellationToken)
        {
            return await _reminderService.DeleteReminderAsync(request.Id);
        }
    }
}
