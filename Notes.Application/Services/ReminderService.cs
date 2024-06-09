using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Resources;
using Notes.Domain.DTO.Reminder;
using Notes.Domain.Entities;
using Notes.Domain.Enum;
using Notes.Domain.Interfaces.Repositories;
using Notes.Domain.Result;

namespace Notes.Application.Services
{
    public class ReminderService : IReminderService
    {
        private readonly IBaseRepository<Reminder> _reminderRepository;
        private readonly IValidator<CreateReminderDTO> _createReminderValidator;
        private readonly IValidator<UpdateReminderDTO> _updateReminderValidator;
        private readonly IMapper _mapper;
        private readonly IBaseRepository<Tag> _tagRepository;

        public ReminderService(IBaseRepository<Reminder> reminderRepository,
                           IValidator<CreateReminderDTO> createReminderValidator,
                           IValidator<UpdateReminderDTO> updateReminderValidator,
                           IMapper mapper,
                           IBaseRepository<Tag> tagRepository)
        {
            _reminderRepository = reminderRepository;
            _createReminderValidator = createReminderValidator;
            _updateReminderValidator = updateReminderValidator;
            _mapper = mapper;
            _tagRepository = tagRepository;
        }

        public async Task<CollectionResult<ReminderDTO>> GetRemindersAsync()
        {
            ReminderDTO[] reminders;

            try
            {
                reminders = await _reminderRepository.GetAll()
                    .AsNoTracking()
                    .Include(n => n.Tags)
                    .Select(n => new ReminderDTO(n.ReminderId, n.Title, n.Text, n.ReminderTime, n.Tags))
                    .ToArrayAsync();
            }
            catch
            {
                return new CollectionResult<ReminderDTO>
                {
                    ErrorMessage = ErrorMessage.InternalServerError,
                    ErrorCode = (int)ErrorCode.InternalServerError
                };
            }

            if (!reminders.Any())
            {
                return new CollectionResult<ReminderDTO>
                {
                    ErrorMessage = ErrorMessage.RemindersNotFound,
                    ErrorCode = (int)ErrorCode.RemindersNotFound
                };
            }

            return new CollectionResult<ReminderDTO>
            {
                Data = reminders,
                Count = reminders.Length
            };
        }

        public async Task<BaseResult<ReminderDTO>> GetReminderByIdAsync(long id)
        {
            ReminderDTO? reminderDTO;
            try
            {
                var reminder = await _reminderRepository.GetAll()
                    .AsNoTracking()
                    .Include(n => n.Tags)
                    .FirstOrDefaultAsync(n => n.ReminderId == id);

                if (reminder == null)
                {
                    return new BaseResult<ReminderDTO>
                    {
                        ErrorMessage = ErrorMessage.ReminderNotFound,
                        ErrorCode = (int)ErrorCode.ReminderNotFound
                    };
                }

                reminderDTO = new ReminderDTO(reminder.ReminderId, reminder.Title, reminder.Text, reminder.ReminderTime, reminder.Tags);
            }
            catch
            {
                return new BaseResult<ReminderDTO>
                {
                    ErrorMessage = ErrorMessage.InternalServerError,
                    ErrorCode = (int)ErrorCode.InternalServerError
                };
            }

            return new BaseResult<ReminderDTO>
            {
                Data = reminderDTO
            };
        }

        public async Task<BaseResult<ReminderDTO>> CreateReminderAsync(CreateReminderDTO dto)
        {
            var result = _createReminderValidator.Validate(dto);

            if (!result.IsValid)
            {
                return new BaseResult<ReminderDTO>
                {
                    ErrorMessage = ErrorMessage.NotValidCreateReminderDTO,
                    ErrorCode = (int)ErrorCode.NotValidCreateReminderDTO
                };
            }

            var reminder = new Reminder
            {
                Title = dto.Title,
                Text = dto.Text
            };

            await _reminderRepository.CreateAsync(reminder);
            await _reminderRepository.SaveChangesAsync();

            return new BaseResult<ReminderDTO>
            {
                Data = _mapper.Map<ReminderDTO>(reminder)
            };
        }

        public async Task<BaseResult<ReminderDTO>> UpdateReminderAsync(UpdateReminderDTO dto)
        {
            var result = _updateReminderValidator.Validate(dto);

            if (!result.IsValid)
            {
                return new BaseResult<ReminderDTO>
                {
                    ErrorMessage = ErrorMessage.NotValidUpdateReminderDTO,
                    ErrorCode = (int)ErrorCode.NotValidUpdateReminderDTO
                };
            }

            var reminder = await _reminderRepository.GetAll().FirstOrDefaultAsync(n => n.ReminderId == dto.ReminderId);

            if (reminder == null)
            {
                return new BaseResult<ReminderDTO>
                {
                    ErrorMessage = ErrorMessage.ReminderNotFound,
                    ErrorCode = (int)ErrorCode.ReminderNotFound
                };
            }

            reminder.Title = dto.Title;
            reminder.Text = dto.Text;

            var updateReminder = _reminderRepository.Update(reminder);
            await _reminderRepository.SaveChangesAsync();

            return new BaseResult<ReminderDTO>
            {
                Data = _mapper.Map<ReminderDTO>(updateReminder)
            };
        }

        public async Task<BaseResult<ReminderDTO>> DeleteReminderAsync(long id)
        {
            var reminder = await _reminderRepository.GetAll().FirstOrDefaultAsync(n => n.ReminderId == id);

            if (reminder == null)
            {
                return new BaseResult<ReminderDTO>
                {
                    ErrorMessage = ErrorMessage.ReminderNotFound,
                    ErrorCode = (int)ErrorCode.ReminderNotFound
                };
            }

            _reminderRepository.Remove(reminder);
            await _reminderRepository.SaveChangesAsync();

            return new BaseResult<ReminderDTO>
            {
                Data = _mapper.Map<ReminderDTO>(reminder)
            };
        }

        public async Task<BaseResult<ReminderDTO>> TagReminder(long id, string name)
        {
            var reminder = await _reminderRepository.GetAll().FirstOrDefaultAsync(r => r.ReminderId == id);

            if (reminder == null)
            {
                return new BaseResult<ReminderDTO>
                {
                    ErrorMessage = ErrorMessage.ReminderNotFound,
                    ErrorCode = (int)ErrorCode.ReminderNotFound
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

            reminder.Tags.Add(tag);

            _reminderRepository.Update(reminder);
            await _reminderRepository.SaveChangesAsync();

            return new BaseResult<ReminderDTO>
            {
                Data = _mapper.Map<ReminderDTO>(reminder)
            };
        }
    }
}