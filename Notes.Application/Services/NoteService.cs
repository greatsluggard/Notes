using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Resources;
using Notes.Domain.DTO.Note;
using Notes.Domain.Entities;
using Notes.Domain.Enum;
using Notes.Domain.Interfaces.Repositories;
using Notes.Domain.Result;

namespace Notes.Application.Services
{
    public class NoteService : INoteService
    {
        private readonly IBaseRepository<Note> _noteRepository;
        private readonly IValidator<CreateNoteDTO> _createNoteValidator;
        private readonly IValidator<UpdateNoteDTO> _updateNoteValidator;
        private readonly IMapper _mapper;
        private readonly IBaseRepository<Tag> _tagRepository;

        public NoteService(IBaseRepository<Note> noteRepository,
                           IValidator<CreateNoteDTO> createNoteValidator,
                           IValidator<UpdateNoteDTO> updateNoteValidator,
                           IMapper mapper,
                           IBaseRepository<Tag> tagRepository)
        {
            _noteRepository = noteRepository;
            _createNoteValidator = createNoteValidator;
            _updateNoteValidator = updateNoteValidator;
            _mapper = mapper;
            _tagRepository = tagRepository;
        }

        public async Task<CollectionResult<NoteDTO>> GetNotesAsync()
        {
            NoteDTO[] notes;

            try
            {
                notes = await _noteRepository.GetAll()
                    .AsNoTracking()
                    .Include(n => n.Tags)
                    .Select(n => new NoteDTO(n.NoteId, n.Title, n.Text, n.Tags))
                    .ToArrayAsync();
            }
            catch
            {
                return new CollectionResult<NoteDTO>
                {
                    ErrorMessage = ErrorMessage.InternalServerError,
                    ErrorCode = (int)ErrorCode.InternalServerError
                };
            }

            if (!notes.Any())
            {
                return new CollectionResult<NoteDTO>
                {
                    ErrorMessage = ErrorMessage.NotesNotFound,
                    ErrorCode = (int)ErrorCode.NotesNotFound
                };
            }

            return new CollectionResult<NoteDTO>
            {
                Data = notes,
                Count = notes.Length
            };
        }

        public async Task<BaseResult<NoteDTO>> GetNoteByIdAsync(long id)
        {
            NoteDTO? noteDTO;
            try
            {
                var note = await _noteRepository.GetAll()
                    .AsNoTracking()
                    .Include(n => n.Tags)
                    .FirstOrDefaultAsync(n => n.NoteId == id);

                if (note == null)
                {
                    return new BaseResult<NoteDTO>
                    {
                        ErrorMessage = ErrorMessage.NoteNotFound,
                        ErrorCode = (int)ErrorCode.NoteNotFound
                    };
                }

                noteDTO = new NoteDTO(note.NoteId, note.Title, note.Text, note.Tags);
            }
            catch
            {
                return new BaseResult<NoteDTO>
                {
                    ErrorMessage = ErrorMessage.InternalServerError,
                    ErrorCode = (int)ErrorCode.InternalServerError
                };
            }

            return new BaseResult<NoteDTO>
            {
                Data = noteDTO
            };
        }


        public async Task<BaseResult<NoteDTO>> CreateNoteAsync(CreateNoteDTO dto)
        {
            var result = _createNoteValidator.Validate(dto);

            if (!result.IsValid)
            {
                return new BaseResult<NoteDTO>
                {
                    ErrorMessage = ErrorMessage.NotValidCreateNoteDTO,
                    ErrorCode = (int)ErrorCode.NotValidCreateNoteDTO
                };
            }

            var note = new Note
            {
                Title = dto.Title,
                Text = dto.Text
            };

            await _noteRepository.CreateAsync(note);
            await _noteRepository.SaveChangesAsync();

            return new BaseResult<NoteDTO>
            {
                Data = _mapper.Map<NoteDTO>(note)
            };
        }

        public async Task<BaseResult<NoteDTO>> UpdateNoteAsync(UpdateNoteDTO dto)
        {
            var result = _updateNoteValidator.Validate(dto);

            if (!result.IsValid)
            {
                return new BaseResult<NoteDTO>
                {
                    ErrorMessage = ErrorMessage.NotValidUpdateNoteDTO,
                    ErrorCode = (int)ErrorCode.NotValidUpdateNoteDTO
                };
            }

            var note = await _noteRepository.GetAll().FirstOrDefaultAsync(n => n.NoteId == dto.NoteId);

            if (note == null)
            {
                return new BaseResult<NoteDTO>
                {
                    ErrorMessage = ErrorMessage.NoteNotFound,
                    ErrorCode = (int)ErrorCode.NoteNotFound
                };
            }

            note.Title = dto.Title;
            note.Text = dto.Text;

            var updateNote = _noteRepository.Update(note);
            await _noteRepository.SaveChangesAsync();

            return new BaseResult<NoteDTO>
            {
                Data = _mapper.Map<NoteDTO>(updateNote)
            };
        }

        public async Task<BaseResult<NoteDTO>> DeleteNoteAsync(long id)
        {
            var note = await _noteRepository.GetAll().FirstOrDefaultAsync(n => n.NoteId == id);

            if (note == null)
            {
                return new BaseResult<NoteDTO>
                {
                    ErrorMessage = ErrorMessage.NoteNotFound,
                    ErrorCode = (int)ErrorCode.NoteNotFound
                };
            }

            _noteRepository.Remove(note);
            await _noteRepository.SaveChangesAsync();

            return new BaseResult<NoteDTO>
            {
                Data = _mapper.Map<NoteDTO>(note)
            };
        }

        public async Task<BaseResult<NoteDTO>> TagNote(long id, string name)
        {
            var note = await _noteRepository.GetAll().FirstOrDefaultAsync(n => n.NoteId == id);

            if (note == null)
            {
                return new BaseResult<NoteDTO>
                {
                    ErrorMessage = ErrorMessage.NoteNotFound,
                    ErrorCode = (int)ErrorCode.NoteNotFound
                };
            }

            var tag = await _tagRepository.GetAll().FirstOrDefaultAsync(t => t.Name == name);
            if (tag == null)
            {
                tag = new Tag
                {
                    Name = name
                };

                await _tagRepository.CreateAsync(tag);
                await _tagRepository.SaveChangesAsync();
            }

            note.Tags.Add(tag);

            _noteRepository.Update(note);
            await _noteRepository.SaveChangesAsync();

            return new BaseResult<NoteDTO>
            {
                Data = _mapper.Map<NoteDTO>(note)
            };
        }
    }
}