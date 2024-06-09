using Notes.Domain.DTO.Note;
using Notes.Domain.Result;

namespace Notes.Application.Services
{
    public interface INoteService
    {
        Task<CollectionResult<NoteDTO>> GetNotesAsync();
        Task<BaseResult<NoteDTO>> GetNoteByIdAsync(long id);
        Task<BaseResult<NoteDTO>> CreateNoteAsync(CreateNoteDTO dto);
        Task<BaseResult<NoteDTO>> UpdateNoteAsync(UpdateNoteDTO dto);
        Task<BaseResult<NoteDTO>> DeleteNoteAsync(long id);
        Task<BaseResult<NoteDTO>> TagNote(long id, string name);
    }
}