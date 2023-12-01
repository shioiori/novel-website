using NovelWebsite.Application.Models.Dtos;
using NovelWebsite.Application.Models.Filters;
using NovelWebsite.NovelWebsite.Application.Interfaces;
using NovelWebsite.Application.Models.Requests;

namespace NovelWebsite.Application.Interfaces
{
    public interface IReviewService : IService<ReviewDto>
    {
        Task<IEnumerable<ReviewDto>> FilterAsync(ReviewFilter filter, PagedListRequest request);
        Task<ReviewDto> GetByIdAsync(string reviewId);
    }
}