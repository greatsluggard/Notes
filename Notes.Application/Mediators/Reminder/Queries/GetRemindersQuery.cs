using MediatR;
using Notes.Domain.DTO.Reminder;
using Notes.Domain.Result;

namespace Notes.Application.Mediators.Reminder.Queries
{
    public class GetRemindersQuery : IRequest<CollectionResult<ReminderDTO>>
    {
    }
}
