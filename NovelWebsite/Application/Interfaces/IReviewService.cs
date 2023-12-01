using Application.Models.Dtos;
using Application.Models.Filter;
using NovelWebsite.Application.Interfaces;
using NovelWebsite.Application.Models.Request;

namespace Application.Interfaces
{
    public interface IReviewService : IService<ReviewDto>
    {
        Task<IEnumerable<ReviewDto>> FilterAsync(ReviewFilter filter, PagedListRequest request);
        Task<ReviewDto> GetByIdAsync(string reviewId);
    }
}