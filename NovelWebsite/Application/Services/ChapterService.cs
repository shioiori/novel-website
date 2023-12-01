using NovelWebsite.Application.Models.Requests;
using NovelWebsite.Application.Utils;
using NovelWebsite.Application.Models.Dtos;
using Application.Services.Base;
using NovelWebsite.Domain.Entities;
using NovelWebsite.Domain.Enums;
using NovelWebsite.Domain.Interfaces;
using AutoMapper;
using NovelWebsite.Application.Models.Filters;
using NovelWebsite.Application.Interfaces;

namespace NovelWebsite.Application.Services
{
    public class ChapterService : GenericService<Chapter, ChapterDto>, IChapterService
    {
        public ChapterService(IChapterRepository chapterRepository, IMapper mapper) : base(chapterRepository, mapper) { }

        public async Task<IEnumerable<ChapterDto>> FilterAsync(ChapterFilter filter, PagedListRequest request)
        {
            var query = _repository.Get();
            if (filter == null)
            {
                return await MapDtosAsync(query.AsEnumerable());
            }
            if (filter.BookId != null)
            {
                query = query.Where(x => x.BookId == filter.BookId);
            }
            if (filter.UploadStatus != null)
            {
                query = query.Where(x => x.Status == (int)filter.UploadStatus);
            }
            var chapters = PagedList<Chapter>.AsEnumerable(query, request);
            return await MapDtosAsync(chapters);
        }

        public async Task<ChapterDto> GetAsync(string chapterId)
        {
            var chapter = _repository.Get(x => x.ChapterId == chapterId).FirstOrDefault();
            return await MapDtoAsync(chapter);
        }
        public async Task<ChapterDto> GetAsync(string bookId, int chapterIndex)
        {
            var chapter = _repository.Get(x => x.BookId == bookId && x.ChapterIndex == chapterIndex).FirstOrDefault();
            return await MapDtoAsync(chapter);
        }
        public async Task<ChapterDto> GetNextAsync(string chapterId)
        {
            var chapter = _repository.Get(x => x.ChapterId == chapterId).FirstOrDefault();
            var nextChapter = _repository.Get(x => x.BookId == chapter.BookId && x.ChapterIndex == chapter.ChapterIndex + 1).FirstOrDefault();
            if (nextChapter == null)
            {
                return await MapDtoAsync(chapter);
            }
            return await MapDtoAsync(nextChapter);
        }
        public async Task<ChapterDto> GetNextAsync(string bookId, int chapterIndex)
        {
            var chapter = _repository.Get(x => x.BookId == bookId && x.ChapterIndex == chapterIndex).FirstOrDefault();
            return await GetNextAsync(chapter.ChapterId);
        }
        public async Task<ChapterDto> GetPrevAsync(string chapterId)
        {
            var chapter = _repository.Get(x => x.ChapterId == chapterId).FirstOrDefault();
            var prevChapter = _repository.Get(x => x.BookId == chapter.BookId && x.ChapterIndex == chapter.ChapterIndex - 1).FirstOrDefault();
            if (prevChapter == null)
            {
                return await MapDtoAsync(chapter);
            }
            return await MapDtoAsync(prevChapter);
        }
        public async Task<ChapterDto> GetPrevAsync(string bookId, int chapterIndex)
        {
            var chapter = _repository.Get(x => x.BookId == bookId && x.ChapterIndex == chapterIndex).FirstOrDefault();
            return await GetPrevAsync(chapter.ChapterId);
        }
    }
}
