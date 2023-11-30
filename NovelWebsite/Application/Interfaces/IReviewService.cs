using Application.Models.Dtos;
using Application.Models.Filter;
using NovelWebsite.Application.Interfaces;

namespace Application.Interfaces
{
    public interface IReviewService : IService<ReviewDto>
    {
        Task<IEnumerable<ReviewDto>> FilterAsync(ReviewFilter filter);
        Task<ReviewDto> GetByIdAsync(string reviewId);
    }
}