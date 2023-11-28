﻿using NovelWebsite.NovelWebsite.Infrastructure.Entities;
using NovelWebsite.Application.Enums;
using NovelWebsite.Application.Interfaces;
using NovelWebsite.Application.Interfaces.Repositories;
using NovelWebsite.NovelWebsite.Infrastructure.Repositories;
using NovelWebsite.Application.Interfaces.Services;
using Application.Interfaces;

namespace NovelWebsite.Application.Services
{
    public class ReviewInteractionService : IInteractionService
    {
        private readonly IReviewUserRepository _reviewUserRepository;

        public ReviewInteractionService(IReviewUserRepository reviewUserRepository)
        {
            _reviewUserRepository = reviewUserRepository;
        }

        public async Task<bool> IsInteractionEnabledAsync(string tId, string uId, InteractionType type)
        {
            var review = await _reviewUserRepository.GetByExpressionAsync(x => x.ReviewId == tId && x.UserId == uId && x.InteractionId == (int)type);
            if (review == null)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> SetStatusOfInteractionAsync(string tId, string uId, InteractionType type)
        {
            var review = await _reviewUserRepository.GetByExpressionAsync(x => x.ReviewId == tId && x.UserId == uId && x.InteractionId == (int)type);
            if (review == null)
            {
                review = new ReviewUsers()
                {
                    ReviewId = tId,
                    UserId = uId,
                    InteractionId = (int)type,
                };
                await _reviewUserRepository.InsertAsync(review);
                _reviewUserRepository.SaveAsync();
                return true;
            }
            _reviewUserRepository.Delete(review);
            _reviewUserRepository.SaveAsync();
            return false;
        }

    }
}
