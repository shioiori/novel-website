using NovelWebsite.NovelWebsite.Core.Enums;
using NovelWebsite.NovelWebsite.Core.Models;

namespace NovelWebsite.NovelWebsite.Core.Interfaces.Services
{
    public interface IChapterService
    {
        void CreateChapter(ChapterModel chapter);
        void DeleteChapter(int chapterId);
        ChapterModel GetChapter(int chapterId);
        IEnumerable<ChapterModel> GetChapters(int bookId);
        IEnumerable<ChapterModel> GetChaptersByStatus(int bookId, UploadStatus uploadStatus);
        ChapterModel GetNextChapter(int chapterId);
        ChapterModel GetPrevChapter(int chapterId);
        void UpdateChapter(ChapterModel chapter);
    }
}
