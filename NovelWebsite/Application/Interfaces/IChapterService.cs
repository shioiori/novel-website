using Application.Models.Dtos;
using Application.Models.Filters;
using NovelWebsite.Application.Interfaces;

namespace Application.Interfaces
{
    public interface IChapterService : IService<ChapterDto>
    {
        Task<IEnumerable<ChapterDto>> FilterAsync(ChapterFilter filter);
        Task<ChapterDto> GetAsync(string chapterId);
        Task<ChapterDto> GetAsync(string bookId, int chapterIndex);
        Task<ChapterDto> GetNextAsync(string chapterId);
        Task<ChapterDto> GetNextAsync(string bookId, int chapterIndex);
        Task<ChapterDto> GetPrevAsync(string chapterId);
        Task<ChapterDto> GetPrevAsync(string bookId, int chapterIndex);
    }
}