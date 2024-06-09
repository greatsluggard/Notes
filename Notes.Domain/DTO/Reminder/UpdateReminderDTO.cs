namespace Notes.Domain.DTO.Reminder
{
    public record class UpdateReminderDTO(long ReminderId, string Title, string Text);
}