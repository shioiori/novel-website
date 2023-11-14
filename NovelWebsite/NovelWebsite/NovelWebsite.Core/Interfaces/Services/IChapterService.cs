using NovelWebsite.NovelWebsite.Core.Enums;
using NovelWebsite.NovelWebsite.Core.Models;

namespace NovelWebsite.NovelWebsite.Core.Interfaces.Services
{
    public interface IChapterService
    {
        void CreateChapter(ChapterModel chapter);
        void DeleteChapter(string chapterId);
        ChapterModel GetChapter(string chapterId);
        IEnumerable<ChapterModel> GetChapters(string bookId);
        IEnumerable<ChapterModel> GetChaptersByStatus(string bookId, UploadStatus uploadStatus);
        ChapterModel GetNextChapter(string chapterId);
        ChapterModel GetPrevChapter(string chapterId);
        void UpdateChapter(ChapterModel chapter);
    }
}
