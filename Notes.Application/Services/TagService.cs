using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Resources;
using Notes.Domain.DTO.Reminder;
using Notes.Domain.DTO.Tag;
using Notes.Domain.Entities;
using Notes.Domain.Enum;
using Notes.Domain.Interfaces.Repositories;
using Notes.Domain.Result;

namespace Notes.Application.Services
{
    public class TagService : ITagService
    {
        private readonly IBaseRepository<Tag> _tagRepository;
        private readonly IValidator<CreateTagDTO> _createTagValidator;
        private readonly IValidator<UpdateTagDTO> _updateTagValidator;
        private readonly IMapper _mapper;

        public TagService(IBaseRepository<Tag> tagRepository,
                           IValidator<CreateTagDTO> createTagValidator,
                           IValidator<UpdateTagDTO> updateTagValidator,
                           IMapper mapper)
        {
            _tagRepository = tagRepository;
            _createTagValidator = createTagValidator;
            _updateTagValidator = updateTagValidator;
            _mapper = mapper;
        }

        public async Task<CollectionResult<TagDTO>> GetTagsAsync()
        {
            TagDTO[] tags;

            try
            {
                tags = await _tagRepository.GetAll()
                    .AsNoTracking()
                    .Select(n => new TagDTO(n.TagId, n.Name))
                    .ToArrayAsync();
            }
            catch
            {
                return new CollectionResult<TagDTO>
                {
                    ErrorMessage = ErrorMessage.InternalServerError,
                    ErrorCode = (int)ErrorCode.InternalServerError
                };
            }

            if (!tags.Any())
            {
                return new CollectionResult<TagDTO>
                {
                    ErrorMessage = ErrorMessage.TagsNotFound,
                    ErrorCode = (int)ErrorCode.TagsNotFound
                };
            }

            return new CollectionResult<TagDTO>
            {
                Data = tags,
                Count = tags.Length
            };
        }

        public async Task<BaseResult<TagDTO>> GetTagByIdAsync(long id)
        {
            TagDTO? tagDTO;
            try
            {
                var tag = await _tagRepository.GetAll()
                    .AsNoTracking()
                    .FirstOrDefaultAsync(n => n.TagId == id);

                if (tag == null)
                {
                    return new BaseResult<TagDTO>
                    {
                        ErrorMessage = ErrorMessage.TagNotFound,
                        ErrorCode = (int)ErrorCode.TagNotFound
                    };
                }

                tagDTO = new TagDTO(tag.TagId, tag.Name);
            }
            catch
            {
                return new BaseResult<TagDTO>
                {
                    ErrorMessage = ErrorMessage.InternalServerError,
                    ErrorCode = (int)ErrorCode.InternalServerError
                };
            }

            return new BaseResult<TagDTO>
            {
                Data = tagDTO
            };
        }

        public async Task<BaseResult<TagDTO>> CreateTagAsync(CreateTagDTO dto)
        {
            var result = _createTagValidator.Validate(dto);

            if (!result.IsValid)
            {
                return new BaseResult<TagDTO>
                {
                    ErrorMessage = ErrorMessage.NotValidCreateTagDTO,
                    ErrorCode = (int)ErrorCode.NotValidCreateTagDTO
                };
            }

            var tag = new Tag
            {
                Name = dto.Name
            };

            await _tagRepository.CreateAsync(tag);
            await _tagRepository.SaveChangesAsync();

            return new BaseResult<TagDTO>
            {
                Data = _mapper.Map<TagDTO>(tag)
            };
        }

        public async Task<BaseResult<TagDTO>> UpdateTagAsync(UpdateTagDTO dto)
        {
            var result = _updateTagValidator.Validate(dto);

            if (!result.IsValid)
            {
                return new BaseResult<TagDTO>
                {
                    ErrorMessage = ErrorMessage.NotValidUpdateTagDTO,
                    ErrorCode = (int)ErrorCode.NotValidUpdateTagDTO
                };
            }

            var tag = await _tagRepository.GetAll().FirstOrDefaultAsync(n => n.TagId == dto.TagId);

            if (tag == null)
            {
                return new BaseResult<TagDTO>
                {
                    ErrorMessage = ErrorMessage.TagNotFound,
                    ErrorCode = (int)ErrorCode.TagNotFound
                };
            }

            tag.Name = dto.Name;

            var updateTag = _tagRepository.Update(tag);
            await _tagRepository.SaveChangesAsync();

            return new BaseResult<TagDTO>
            {
                Data = _mapper.Map<TagDTO>(updateTag)
            };
        }

        public async Task<BaseResult<TagDTO>> DeleteTagAsync(long id)
        {
            var tag = await _tagRepository.GetAll().FirstOrDefaultAsync(n => n.TagId == id);

            if (tag == null)
            {
                return new BaseResult<TagDTO>
                {
                    ErrorMessage = ErrorMessage.TagNotFound,
                    ErrorCode = (int)ErrorCode.TagNotFound
                };
            }

            _tagRepository.Remove(tag);
            await _tagRepository.SaveChangesAsync();

            return new BaseResult<TagDTO>
            {
                Data = _mapper.Map<TagDTO>(tag)
            };
        }
    }
}