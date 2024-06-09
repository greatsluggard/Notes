using Notes.Domain.DTO.Tag;
using Notes.Domain.Result;

namespace Notes.Application.Services
{
    public interface ITagService
    {
        Task<CollectionResult<TagDTO>> GetTagsAsync();
        Task<BaseResult<TagDTO>> GetTagByIdAsync(long id);
        Task<BaseResult<TagDTO>> CreateTagAsync(CreateTagDTO dto);
        Task<BaseResult<TagDTO>> UpdateTagAsync(UpdateTagDTO dto);
        Task<BaseResult<TagDTO>> DeleteTagAsync(long id);
    }
}