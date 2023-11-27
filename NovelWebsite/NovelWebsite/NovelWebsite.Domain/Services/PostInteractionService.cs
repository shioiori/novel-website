using NovelWebsite.NovelWebsite.Infrastructure.Entities;
using NovelWebsite.NovelWebsite.Core.Enums;
using NovelWebsite.NovelWebsite.Core.Interfaces.Repositories;
using NovelWebsite.NovelWebsite.Core.Interfaces.Services;

namespace NovelWebsite.NovelWebsite.Domain.Services
{
    public class PostInteractionService : IInteractionService
    {
        private readonly IPostUserRepository _postUserRepository;

        public PostInteractionService(IPostUserRepository postUserRepository)
        {
            _postUserRepository = postUserRepository;
        }

        public async Task<bool> IsInteractionEnabledAsync(string tId, string uId, InteractionType type)
        {
            var post = await _postUserRepository.GetByExpressionAsync(x => x.PostId == tId && x.UserId == uId && x.InteractionId == (int)type);
            if (post == null)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> SetStatusOfInteractionAsync(string tId, string uId, InteractionType type)
        {
            var post = await _postUserRepository.GetByExpressionAsync(x => x.PostId == tId && x.UserId == uId && x.InteractionId == (int)type);
            if (post == null)
            {
                post = new PostUsers()
                {
                    PostId = tId,
                    UserId = uId,
                    InteractionId = (int)type,
                };
                await _postUserRepository.InsertAsync(post);
                _postUserRepository.SaveAsync();
                return true;
            }
            _postUserRepository.Delete(post);
            _postUserRepository.SaveAsync();
            return false;
        }

    }
}
