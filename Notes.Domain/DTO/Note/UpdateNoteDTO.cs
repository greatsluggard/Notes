namespace Notes.Domain.DTO.Note
{
    public record class UpdateNoteDTO(long NoteId, string Title, string Text);
}