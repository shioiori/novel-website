using NovelWebsite.Application.Interfaces;
using Application.Services.Base;
using NovelWebsite.Application.Models.Dtos;
using NovelWebsite.Domain.Entities;
using NovelWebsite.Domain.Enums;
using NovelWebsite.Domain.Interfaces;
using AutoMapper;

namespace NovelWebsite.Application.Services
{
    public class ReviewInteractionService : GenericService<ReviewUsers, ReviewUserDto>, IReviewInteractionService
    {
        public ReviewInteractionService(IReviewUserRepository reviewUserRepository, IMapper mapper) : base(reviewUserRepository, mapper) { }

        public async Task<bool> IsInteractionEnabledAsync(string tId, string uId, InteractionType type)
        {
            var review = _repository.Get(x => x.ReviewId == tId && x.UserId == uId && x.InteractionId == (int)type).FirstOrDefault();
            if (review == null)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> SetStatusOfInteractionAsync(string tId, string uId, InteractionType type)
        {
            var review = _repository.Get(x => x.ReviewId == tId && x.UserId == uId && x.InteractionId == (int)type).FirstOrDefault();
            if (review == null)
            {
                review = new ReviewUsers()
                {
                    ReviewId = tId,
                    UserId = uId,
                    InteractionId = (int)type,
                };
                await _repository.InsertAsync(review);
                _repository.SaveAsync();
                return true;
            }
            _repository.Delete(review);
            _repository.SaveAsync();
            return false;
        }

    }
}
