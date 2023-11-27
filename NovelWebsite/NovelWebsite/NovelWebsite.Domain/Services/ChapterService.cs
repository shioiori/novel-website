using AutoMapper;
using NovelWebsite.NovelWebsite.Infrastructure.Entities;
using NovelWebsite.NovelWebsite.Core.Enums;
using NovelWebsite.NovelWebsite.Core.Interfaces.Repositories;
using NovelWebsite.NovelWebsite.Core.Interfaces.Services;
using NovelWebsite.NovelWebsite.Core.Models;
using NovelWebsite.NovelWebsite.Core.Models.Request;
using NovelWebsite.NovelWebsite.Core.Models.Response;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace NovelWebsite.NovelWebsite.Domain.Services
{
    public class ChapterService 
    {
        private readonly IChapterRepository _chapterRepository;
        private readonly IMapper _mapper;

        public ChapterService(IChapterRepository chapterRepository, IMapper mapper) 
        {
            _chapterRepository = chapterRepository;
            _mapper = mapper;
        }

        public IEnumerable<ChapterModel> GetChapters(string bookId, PagedListRequest pagedListRequest = null)
        {
            var query = _chapterRepository.Filter(x => x.BookId == bookId);
            var chapters = PagedList<Chapter>.AsEnumerable(query, pagedListRequest);
            return _mapper.Map<IEnumerable<Chapter>, IEnumerable<ChapterModel>>(chapters);
        }

        public IEnumerable<ChapterModel> GetChaptersByStatus(string bookId, UploadStatus uploadStatus, PagedListRequest pagedListRequest = null)
        {
            var query = _chapterRepository.Filter(x => x.BookId == bookId && x.Status == (int)uploadStatus);
            var chapters = PagedList<Chapter>.AsEnumerable(query, pagedListRequest);
            return _mapper.Map<IEnumerable<Chapter>, IEnumerable<ChapterModel>>(chapters);
        }

        public async Task<ChapterModel> GetChapterAsync(string chapterId)
        {
            var chapter = await _chapterRepository.GetByIdAsync(chapterId);
            return _mapper.Map<Chapter, ChapterModel>(chapter);
        }

        public async Task<ChapterModel> GetChapterAsync(string bookId, int chapterIndex)
        {
            var chapter = await _chapterRepository.GetByExpressionAsync(x => x.BookId == bookId && x.ChapterIndex == chapterIndex);
            return _mapper.Map<Chapter, ChapterModel>(chapter);
        }
        public async Task<ChapterModel> GetNextChapterAsync(string chapterId)
        {
            var chapter = await _chapterRepository.GetByIdAsync(chapterId);
            var nextChapter = await _chapterRepository.GetByExpressionAsync(x => x.BookId == chapter.BookId && x.ChapterIndex == chapter.ChapterIndex + 1);
            if (nextChapter == null)
            {
                return _mapper.Map<Chapter, ChapterModel>(chapter);
            }
            return _mapper.Map<Chapter, ChapterModel>(nextChapter);
        }

        public async Task<ChapterModel> GetPrevChapterAsync(string chapterId)
        {
            var chapter = await _chapterRepository.GetByIdAsync(chapterId);
            var prevChapter = await _chapterRepository.GetByExpressionAsync(x => x.BookId == chapter.BookId && x.ChapterIndex == chapter.ChapterIndex - 1);
            if (prevChapter == null)
            {
                return _mapper.Map<Chapter, ChapterModel>(chapter); 
            }
            return _mapper.Map<Chapter, ChapterModel>(prevChapter);
        }

        public async Task CreateChapterAsync(ChapterModel chapter)
        {
            if (chapter.ChapterNumber == 0)
            {
                chapter.ChapterNumber = await _chapterRepository.CountAsync(x => x.BookId == chapter.BookId) + 1;
            }
            _chapterRepository.InsertAsync(_mapper.Map<ChapterModel, Chapter>(chapter));
            _chapterRepository.SaveAsync();
        }
        public async Task UpdateChapterAsync(ChapterModel chapter)
        {
            if (chapter.ChapterNumber == 0)
            {
                var entity = await _chapterRepository.GetByExpressionAsync(x => x.ChapterId == chapter.ChapterId);
                if (entity == null) {  return; }
                chapter.ChapterNumber = entity.ChapterIndex;
            }
            _chapterRepository.UpdateAsync(_mapper.Map<ChapterModel, Chapter>(chapter));
            _chapterRepository.SaveAsync();
        }

        public async Task DeleteChapterAsync(string chapterId)
        {
            await _chapterRepository.DeleteAsync(chapterId);
            _chapterRepository.SaveAsync();
        }

    }
}
