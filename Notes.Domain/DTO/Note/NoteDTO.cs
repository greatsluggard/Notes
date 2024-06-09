namespace Notes.Domain.DTO.Note
{
    public record class NoteDTO(long NoteId, string Title, string Text, List<Entities.Tag> Tags);
}