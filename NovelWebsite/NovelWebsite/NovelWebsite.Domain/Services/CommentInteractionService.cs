using NovelWebsite.Infrastructure.Entities;
using NovelWebsite.NovelWebsite.Core.Enums;
using NovelWebsite.NovelWebsite.Core.Interfaces.Repositories;
using NovelWebsite.NovelWebsite.Infrastructure.Repositories;

namespace NovelWebsite.NovelWebsite.Domain.Services
{
    public class CommentInteractionService : InterationService
    {
        private readonly ICommentUserRepository _commentUserRepository;

        public CommentInteractionService(ICommentUserRepository commentUserRepository)
        {
            _commentUserRepository = commentUserRepository;
        }

        public override bool IsInteractionEnabled(int tId, int uId, InteractionType type)
        {
            var comment = _commentUserRepository.Filter(x => x.CommentId == tId && x.UserId == uId && x.InteractType == (int)type);
            if (comment == null)
            {
                return false;
            }
            return true;
        }
        public override bool SetStatusOfInteraction(int tId, int uId, InteractionType type)
        {
            var comment = _commentUserRepository.GetById(x => x.CommentId == tId && x.UserId == uId && x.InteractType == (int)type);
            if (comment == null)
            {
                comment = new Comment_User()
                {
                    CommentId = tId,
                    UserId = uId,
                    InteractType = (int)type,
                };
                _commentUserRepository.Insert(comment);
                return true;
            }
            _commentUserRepository.Delete(comment);
            return false;
        }

    }
}
