using NovelWebsite.Infrastructure.Entities;
using NovelWebsite.NovelWebsite.Core.Enums;
using NovelWebsite.NovelWebsite.Core.Interfaces.Repositories;
using NovelWebsite.NovelWebsite.Infrastructure.Repositories;

namespace NovelWebsite.NovelWebsite.Domain.Services
{
    public class PostInteractionService : InterationService
    {
        private readonly IPostUserRepository _postUserRepository;

        public PostInteractionService(IPostUserRepository postUserRepository)
        {
            _postUserRepository = postUserRepository;
        }

        public override bool IsInteractionEnabled(int tId, int uId, InteractionType type)
        {
            var post = _postUserRepository.Filter(x => x.PostId == tId && x.UserId == uId && x.InteractType == (int)type);
            if (post == null)
            {
                return false;
            }
            return true;
        }

        public override bool SetStatusOfInteraction(int tId, int uId, InteractionType type)
        {
            var post = _postUserRepository.GetByExpression(x => x.PostId == tId && x.UserId == uId && x.InteractType == (int)type);
            if (post == null)
            {
                post = new Post_User()
                {
                    PostId = tId,
                    UserId = uId,
                    InteractType = (int)type,
                };
                _postUserRepository.Insert(post);
                return true;
            }
            _postUserRepository.Delete(post);
            return false;
        }

    }
}
