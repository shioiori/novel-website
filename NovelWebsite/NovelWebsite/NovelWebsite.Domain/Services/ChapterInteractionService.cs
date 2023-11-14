using NovelWebsite.NovelWebsite.Infrastructure.Entities;
using NovelWebsite.NovelWebsite.Core.Enums;
using NovelWebsite.NovelWebsite.Core.Interfaces;
using NovelWebsite.NovelWebsite.Core.Interfaces.Repositories;

namespace NovelWebsite.NovelWebsite.Domain.Services
{
    public class ChapterInteractionService : InterationService
    {
        private readonly IChapterUserRepository _chapterUserRepository;

        public ChapterInteractionService(IChapterUserRepository chapterUserRepository)
        {
            _chapterUserRepository = chapterUserRepository;
        }

        public override bool IsInteractionEnabled(string tId, string uId, InteractionType type)
        {
            var chapter = _chapterUserRepository.Filter(x => x.ChapterId == tId && x.UserId == uId && x.InteractionId == (int)type);
            if (chapter == null)
            {
                return false;
            }
            return true;
        }
        public override bool SetStatusOfInteraction(string tId, string uId, InteractionType type)
        {
            var chapter = _chapterUserRepository.GetByExpression(x => x.ChapterId == tId && x.UserId == uId && x.InteractionId == (int)type);
            if (chapter == null)
            {
                chapter = new ChapterUsers()
                {
                    ChapterId = tId,
                    UserId = uId,
                    InteractionId = (int)type,
                };
                _chapterUserRepository.Insert(chapter);
                _chapterUserRepository.Save();
                return true;
            }
            _chapterUserRepository.Delete(chapter);
            _chapterUserRepository.Save();
            return false;
        }

    }
}
