using MediatR;
using Notes.Application.Mediators.Reminder.Queries;
using Notes.Application.Services;
using Notes.Domain.DTO.Reminder;
using Notes.Domain.Result;

namespace Reminders.Application.Mediators.Reminder.Handlers
{
    public class GetRemindersQueryHandler : IRequestHandler<GetRemindersQuery, CollectionResult<ReminderDTO>>
    {
        private readonly IReminderService _reminderService;

        public GetRemindersQueryHandler(IReminderService reminderService)
        {
            _reminderService = reminderService;
        }

        public async Task<CollectionResult<ReminderDTO>> Handle(GetRemindersQuery request, CancellationToken cancellationToken)
        {
            return await _reminderService.GetRemindersAsync();
        }
    }
}
