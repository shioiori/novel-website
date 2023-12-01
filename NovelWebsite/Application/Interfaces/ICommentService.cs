using NovelWebsite.Application.Models.Dtos;
using NovelWebsite.Application.Models.Filters;
using NovelWebsite.NovelWebsite.Application.Interfaces;
using NovelWebsite.Application.Models.Requests;

namespace NovelWebsite.Application.Interfaces
{
    public interface ICommentService : IService<CommentDto>
    {
        Task<IEnumerable<CommentDto>> FilterAsync(CommentFilter filter, PagedListRequest pagedListRequest);
        Task<CommentDto> GetByIdAsync(string commentId);
        Task<IEnumerable<CommentDto>> GetRepliesAsync(string commentId, PagedListRequest pagedListRequest);
    }
}