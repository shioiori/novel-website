using NovelWebsite.NovelWebsite.Infrastructure.Entities;
using NovelWebsite.NovelWebsite.Core.Enums;
using NovelWebsite.NovelWebsite.Core.Interfaces.Repositories;
using NovelWebsite.NovelWebsite.Infrastructure.Repositories;

namespace NovelWebsite.NovelWebsite.Domain.Services
{
    public class PostInteractionService : InteractionService
    {
        private readonly IPostUserRepository _postUserRepository;

        public PostInteractionService(IPostUserRepository postUserRepository)
        {
            _postUserRepository = postUserRepository;
        }

        public override bool IsInteractionEnabled(string tId, string uId, InteractionType type)
        {
            var post = _postUserRepository.Filter(x => x.PostId == tId && x.UserId == uId && x.InteractionId == (int)type);
            if (post == null)
            {
                return false;
            }
            return true;
        }

        public override bool SetStatusOfInteraction(string tId, string uId, InteractionType type)
        {
            var post = _postUserRepository.GetByExpression(x => x.PostId == tId && x.UserId == uId && x.InteractionId == (int)type);
            if (post == null)
            {
                post = new PostUsers()
                {
                    PostId = tId,
                    UserId = uId,
                    InteractionId = (int)type,
                };
                _postUserRepository.Insert(post);
                _postUserRepository.Save();
                return true;
            }
            _postUserRepository.Delete(post);
            _postUserRepository.Save();
            return false;
        }

    }
}
