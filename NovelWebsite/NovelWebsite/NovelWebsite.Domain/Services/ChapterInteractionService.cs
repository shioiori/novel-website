using NovelWebsite.Infrastructure.Entities;
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

        public override bool IsInteractionEnabled(int tId, int uId, InteractionType type)
        {
            var chapter = _chapterUserRepository.Filter(x => x.ChapterId == tId && x.UserId == uId && x.InteractType == (int)type);
            if (chapter == null)
            {
                return false;
            }
            return true;
        }
        public override bool SetStatusOfInteraction(int tId, int uId, InteractionType type)
        {
            var chapter = _chapterUserRepository.GetById(x => x.ChapterId == tId && x.UserId == uId && x.InteractType == (int)type);
            if (chapter == null)
            {
                chapter = new Chapter_User()
                {
                    ChapterId = tId,
                    UserId = uId,
                    InteractType = (int)type,
                };
                _chapterUserRepository.Insert(chapter);
                return true;
            }
            _chapterUserRepository.Delete(chapter);
            return false;
        }

    }
}
