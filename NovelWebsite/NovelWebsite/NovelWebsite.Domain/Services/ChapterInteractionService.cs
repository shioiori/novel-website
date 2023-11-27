using NovelWebsite.NovelWebsite.Infrastructure.Entities;
using NovelWebsite.NovelWebsite.Core.Enums;
using NovelWebsite.NovelWebsite.Core.Interfaces.Repositories;
using NovelWebsite.NovelWebsite.Core.Interfaces.Services;

namespace NovelWebsite.NovelWebsite.Domain.Services
{
    public class ChapterInteractionService : IInteractionService
    {
        private readonly IChapterUserRepository _chapterUserRepository;

        public ChapterInteractionService(IChapterUserRepository chapterUserRepository)
        {
            _chapterUserRepository = chapterUserRepository;
        }

        public async Task<bool> IsInteractionEnabledAsync(string tId, string uId, InteractionType type)
        {
            var chapter = await _chapterUserRepository.GetByExpressionAsync(x => x.ChapterId == tId && x.UserId == uId && x.InteractionId == (int)type);
            if (chapter == null)
            {
                return false;
            }
            return true;
        }
        public async Task<bool> SetStatusOfInteractionAsync(string tId, string uId, InteractionType type)
        {
            var chapter = await _chapterUserRepository.GetByExpressionAsync(x => x.ChapterId == tId && x.UserId == uId && x.InteractionId == (int)type);
            if (chapter == null)
            {
                chapter = new ChapterUsers()
                {
                    ChapterId = tId,
                    UserId = uId,
                    InteractionId = (int)type,
                };
                await _chapterUserRepository.InsertAsync(chapter);
                _chapterUserRepository.SaveAsync();
                return true;
            }
            _chapterUserRepository.Delete(chapter);
            _chapterUserRepository.SaveAsync();
            return false;
        }

    }
}
