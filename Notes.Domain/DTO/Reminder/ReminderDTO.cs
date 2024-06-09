namespace Notes.Domain.DTO.Reminder
{
    public record class ReminderDTO(long ReminderId, string Title, string Text, DateTime ReminderTime, List<Entities.Tag> Tags);
}