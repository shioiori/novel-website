using NovelWebsite.NovelWebsite.Infrastructure.Entities;
using NovelWebsite.NovelWebsite.Core.Enums;
using NovelWebsite.NovelWebsite.Core.Interfaces.Repositories;
using NovelWebsite.NovelWebsite.Core.Interfaces.Services;

namespace NovelWebsite.NovelWebsite.Domain.Services
{
    public class CommentInteractionService : IInteractionService
    {
        private readonly ICommentUserRepository _commentUserRepository;

        public CommentInteractionService(ICommentUserRepository commentUserRepository)
        {
            _commentUserRepository = commentUserRepository;
        }

        public async Task<bool> IsInteractionEnabledAsync(string tId, string uId, InteractionType type)
        {
            var comment = await _commentUserRepository.GetByExpressionAsync(x => x.CommentId == tId && x.UserId == uId && x.InteractionId == (int)type);
            if (comment == null)
            {
                return false;
            }
            return true;
        }
        public async Task<bool> SetStatusOfInteractionAsync(string tId, string uId, InteractionType type)
        {
            var comment = await _commentUserRepository.GetByExpressionAsync(x => x.CommentId == tId && x.UserId == uId && x.InteractionId == (int)type);
            if (comment == null)
            {
                comment = new CommentUsers()
                {
                    CommentId = tId,
                    UserId = uId,
                    InteractionId = (int)type,
                };
                await _commentUserRepository.InsertAsync(comment);
                _commentUserRepository.SaveAsync();
                return true;
            }
            _commentUserRepository.Delete(comment);
            _commentUserRepository.SaveAsync();
            return false;
        }

    }
}
