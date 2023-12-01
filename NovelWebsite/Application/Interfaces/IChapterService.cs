using NovelWebsite.Application.Models.Dtos;
using NovelWebsite.Application.Models.Filters;
using NovelWebsite.NovelWebsite.Application.Interfaces;
using NovelWebsite.Application.Models.Requests;

namespace NovelWebsite.Application.Interfaces
{
    public interface IChapterService : IService<ChapterDto>
    {
        Task<IEnumerable<ChapterDto>> FilterAsync(ChapterFilter filter, PagedListRequest request);
        Task<ChapterDto> GetAsync(string chapterId);
        Task<ChapterDto> GetAsync(string bookId, int chapterIndex);
        Task<ChapterDto> GetNextAsync(string chapterId);
        Task<ChapterDto> GetNextAsync(string bookId, int chapterIndex);
        Task<ChapterDto> GetPrevAsync(string chapterId);
        Task<ChapterDto> GetPrevAsync(string bookId, int chapterIndex);
    }
}