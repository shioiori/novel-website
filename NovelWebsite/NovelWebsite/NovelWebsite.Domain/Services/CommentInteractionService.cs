using NovelWebsite.NovelWebsite.Infrastructure.Entities;
using NovelWebsite.NovelWebsite.Core.Enums;
using NovelWebsite.NovelWebsite.Core.Interfaces.Repositories;
using NovelWebsite.NovelWebsite.Infrastructure.Repositories;

namespace NovelWebsite.NovelWebsite.Domain.Services
{
    public class CommentInteractionService : InteractionService
    {
        private readonly ICommentUserRepository _commentUserRepository;

        public CommentInteractionService(ICommentUserRepository commentUserRepository)
        {
            _commentUserRepository = commentUserRepository;
        }

        public override bool IsInteractionEnabled(string tId, string uId, InteractionType type)
        {
            var comment = _commentUserRepository.Filter(x => x.CommentId == tId && x.UserId == uId && x.InteractionId == (int)type);
            if (comment == null)
            {
                return false;
            }
            return true;
        }
        public override bool SetStatusOfInteraction(string tId, string uId, InteractionType type)
        {
            var comment = _commentUserRepository.GetByExpression(x => x.CommentId == tId && x.UserId == uId && x.InteractionId == (int)type);
            if (comment == null)
            {
                comment = new CommentUsers()
                {
                    CommentId = tId,
                    UserId = uId,
                    InteractionId = (int)type,
                };
                _commentUserRepository.Insert(comment);
                _commentUserRepository.Save();
                return true;
            }
            _commentUserRepository.Delete(comment);
            _commentUserRepository.Save();
            return false;
        }

    }
}
