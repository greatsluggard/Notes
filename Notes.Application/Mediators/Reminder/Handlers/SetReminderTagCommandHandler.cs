using MediatR;
using Notes.Application.Services;
using Notes.Domain.DTO.Reminder;
using Notes.Domain.Result;
using Reminders.Application.Mediators.Reminder.Commands;

namespace Reminders.Application.Mediators.Reminder.Handlers
{
    public class SetReminderTagCommandHandler : IRequestHandler<SetReminderTagCommand, BaseResult<ReminderDTO>>
    {
        private readonly IReminderService _reminderService;

        public SetReminderTagCommandHandler(IReminderService reminderService)
        {
            _reminderService = reminderService;
        }

        public async Task<BaseResult<ReminderDTO>> Handle(SetReminderTagCommand request, CancellationToken cancellationToken)
        {
            return await _reminderService.TagReminder(request.Id, request.Name);
        }
    }
}
