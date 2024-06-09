using System.Text.Json.Serialization;

namespace Notes.Domain.Entities
{
    public class Tag
    {
        public long TagId { get; set; }
        public string Name { get; set; }

        [JsonIgnore]
        public List<Note> Notes { get; set; }

        [JsonIgnore]
        public List<Reminder> Reminders { get; set; }
    }
}