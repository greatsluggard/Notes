namespace Notes.Domain.Entities
{
    public class Note
    {
        public long NoteId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public List<Tag> Tags { get; set; } = new List<Tag>();
    }
}