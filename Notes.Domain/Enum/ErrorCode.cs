namespace Notes.Domain.Enum
{
    public enum ErrorCode
    {
        NotesNotFound = 0,
        NoteNotFound = 1,
        NotValidCreateNoteDTO = 2,
        NotValidUpdateNoteDTO = 3,

        InternalServerError = 10,

        ReminderNotFound = 11,
        RemindersNotFound = 12,
        NotValidCreateReminderDTO = 13,
        NotValidUpdateReminderDTO = 14,

        TagNotFound = 21,
        TagsNotFound = 22,
        NotValidCreateTagDTO = 23,
        NotValidUpdateTagDTO = 24
    }
}