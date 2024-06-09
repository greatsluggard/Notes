using MediatR;
using Notes.Application.Services;
using Notes.Domain.DTO.Reminder;
using Notes.Domain.Result;
using Reminders.Application.Mediators.Reminder.Queries;

namespace Notes.Application.Mediators.Reminder.Handlers
{
    public class GetReminderByIdQueryHandler : IRequestHandler<GetReminderByIdQuery, BaseResult<ReminderDTO>>
    {
        private readonly IReminderService _reminderService;

        public GetReminderByIdQueryHandler(IReminderService reminderService)
        {
            _reminderService = reminderService;
        }

        public async Task<BaseResult<ReminderDTO>> Handle(GetReminderByIdQuery request, CancellationToken cancellationToken)
        {
            return await _reminderService.GetReminderByIdAsync(request.Id);
        }
    }
}
