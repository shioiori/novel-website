using Application.Models.Dtos;
using Application.Models.Filters;
using NovelWebsite.Application.Interfaces;
using NovelWebsite.Application.Models.Request;

namespace Application.Interfaces
{
    public interface ICommentService : IService<CommentDto>
    {
        Task<IEnumerable<CommentDto>> FilterAsync(CommentFilter filter, PagedListRequest pagedListRequest);
        Task<CommentDto> GetByIdAsync(string commentId);
        Task<IEnumerable<CommentDto>> GetRepliesAsync(string commentId, PagedListRequest pagedListRequest);
    }
}