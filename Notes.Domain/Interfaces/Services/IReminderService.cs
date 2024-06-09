using Notes.Domain.DTO.Reminder;
using Notes.Domain.Result;

namespace Notes.Application.Services
{
    public interface IReminderService
    {
        Task<CollectionResult<ReminderDTO>> GetRemindersAsync();
        Task<BaseResult<ReminderDTO>> GetReminderByIdAsync(long id);
        Task<BaseResult<ReminderDTO>> CreateReminderAsync(CreateReminderDTO dto);
        Task<BaseResult<ReminderDTO>> UpdateReminderAsync(UpdateReminderDTO dto);
        Task<BaseResult<ReminderDTO>> DeleteReminderAsync(long id);
        Task<BaseResult<ReminderDTO>> TagReminder(long id, string name);
    }
}