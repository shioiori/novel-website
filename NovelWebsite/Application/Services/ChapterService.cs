using NovelWebsite.Application.Models.Request;
using Application.Utils;
using Application.Models.Dtos;
using Application.Services.Base;
using NovelWebsite.Domain.Entities;
using NovelWebsite.Domain.Enums;

namespace NovelWebsite.Application.Services
{
    public class ChapterService : GenericService<Chapter, ChapterDto>
    {
        public ChapterService() : base() { }

        public async Task<IEnumerable<ChapterDto>> GetChaptersAsync(string bookId, PagedListRequest pagedListRequest = null)
        {
            var query = _repository.Get(x => x.BookId == bookId);
            var chapters = PagedList<Chapter>.AsEnumerable(query, pagedListRequest);
            return await MapDtosAsync(chapters);
        }

        public async Task<IEnumerable<ChapterDto>> GetChaptersByStatusAsync(string bookId, UploadStatus uploadStatus, PagedListRequest pagedListRequest = null)
        {
            var query = _repository.Get(x => x.BookId == bookId && x.Status == (int)uploadStatus);
            var chapters = PagedList<Chapter>.AsEnumerable(query, pagedListRequest);
            return await MapDtosAsync(chapters);
        }

        public async Task<ChapterDto> GetChapterAsync(string chapterId)
        {
            var chapter = _repository.Get(x => x.ChapterId == chapterId).FirstOrDefault();
            return await MapDtosAsync(chapter);
        }

        public async Task<ChapterDto> GetChapterAsync(string bookId, int chapterIndex)
        {
            var chapter = _repository.Get(x => x.BookId == bookId && x.ChapterIndex == chapterIndex).FirstOrDefault();
            return await MapDtosAsync(chapter);
        }
        public async Task<ChapterDto> GetNextChapterAsync(string chapterId)
        {
            var chapter = _repository.Get(x => x.ChapterId == chapterId).FirstOrDefault();
            var nextChapter = _repository.Get(x => x.BookId == chapter.BookId && x.ChapterIndex == chapter.ChapterIndex + 1).FirstOrDefault();
            if (nextChapter == null)
            {
                return await MapDtosAsync(chapter);
            }
            return await MapDtosAsync(nextChapter);
        }

        public async Task<ChapterDto> GetPrevChapterAsync(string chapterId)
        {
            var chapter = _repository.Get(x => x.ChapterId == chapterId).FirstOrDefault();
            var prevChapter = _repository.Get(x => x.BookId == chapter.BookId && x.ChapterIndex == chapter.ChapterIndex - 1).FirstOrDefault();
            if (prevChapter == null)
            {
                return await MapDtosAsync(chapter);
            }
            return await MapDtosAsync(prevChapter);
        }
    }
}
