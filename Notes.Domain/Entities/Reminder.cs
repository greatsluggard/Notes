namespace Notes.Domain.Entities
{
    public class Reminder
    {
        public long ReminderId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime ReminderTime { get; set; } = DateTime.UtcNow.AddDays(1);
        public List<Tag> Tags { get; set; } = new List<Tag>();
    }
}