using NovelWebsite.Infrastructure.Entities;
using NovelWebsite.NovelWebsite.Core.Enums;
using NovelWebsite.NovelWebsite.Core.Interfaces;
using NovelWebsite.NovelWebsite.Core.Interfaces.Repositories;
using NovelWebsite.NovelWebsite.Infrastructure.Repositories;

namespace NovelWebsite.NovelWebsite.Domain.Services
{
    public class ReviewInteractionService : InterationService
    {
        private readonly IReviewUserRepository _reviewUserRepository;

        public ReviewInteractionService(IReviewUserRepository reviewUserRepository)
        {
            _reviewUserRepository = reviewUserRepository;
        }

        public override bool IsInteractionEnabled(int tId, int uId, InteractionType type)
        {
            var review = _reviewUserRepository.Filter(x => x.ReviewId == tId && x.UserId == uId && x.InteractType == (int)type);
            if (review == null)
            {
                return false;
            }
            return true;
        }

        public override bool SetStatusOfInteraction(int tId, int uId, InteractionType type)
        {
            var review = _reviewUserRepository.GetByExpression(x => x.ReviewId == tId && x.UserId == uId && x.InteractType == (int)type);
            if (review == null)
            {
                review = new ReviewUsers()
                {
                    ReviewId = tId,
                    UserId = uId,
                    InteractType = (int)type,
                };
                _reviewUserRepository.Insert(review);
                _reviewUserRepository.Save();
                return true;
            }
            _reviewUserRepository.Delete(review);
            _reviewUserRepository.Save();
            return false;
        }

    }
}
