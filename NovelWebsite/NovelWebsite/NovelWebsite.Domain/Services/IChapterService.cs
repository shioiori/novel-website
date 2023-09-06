using NovelWebsite.NovelWebsite.Core.Enums;
using NovelWebsite.NovelWebsite.Core.Models;

namespace NovelWebsite.NovelWebsite.Domain.Services
{
    public interface IChapterService
    {
        void CreateChapter(ChapterModel chapter);
        void DeleteChapter(int chapterId);
        IEnumerable<ChapterModel> GetChaptersByStatus(int bookId, UploadStatus uploadStatus);
        IEnumerable<ChapterModel> GetChapters(int bookId);
        ChapterModel GetChapter(int chapterId);
        ChapterModel GetNextChapter(int chapterId);
        ChapterModel GetPrevChapter(int chapterId);
        void UpdateChapter(ChapterModel chapter);
    }
}