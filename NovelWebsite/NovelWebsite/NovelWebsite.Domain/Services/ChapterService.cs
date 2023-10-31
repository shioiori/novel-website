using AutoMapper;
using NovelWebsite.Infrastructure.Entities;
using NovelWebsite.NovelWebsite.Core.Enums;
using NovelWebsite.NovelWebsite.Core.Interfaces.Repositories;
using NovelWebsite.NovelWebsite.Core.Interfaces.Services;
using NovelWebsite.NovelWebsite.Core.Models;

namespace NovelWebsite.NovelWebsite.Domain.Services
{
    public class ChapterService : IChapterService
    {
        private readonly IChapterRepository _chapterRepository;
        private readonly IMapper _mapper;

        public ChapterService(IChapterRepository chapterRepository, IMapper mapper) 
        {
            _chapterRepository = chapterRepository;
            _mapper = mapper;
        }

        public IEnumerable<ChapterModel> GetChapters(int bookId)
        {
            var chapters = _chapterRepository.Filter(x => x.BookId == bookId);
            return _mapper.Map<IEnumerable<Chapter>, IEnumerable<ChapterModel>>(chapters);
        }

        public IEnumerable<ChapterModel> GetChaptersByStatus(int bookId, UploadStatus uploadStatus)
        {
            var chapters = _chapterRepository.Filter(x => x.BookId == bookId && x.Status == (int)uploadStatus);
            return _mapper.Map<IEnumerable<Chapter>, IEnumerable<ChapterModel>>(chapters);
        }

        public ChapterModel GetChapter(int chapterId)
        {
            var chapter = _chapterRepository.GetById(chapterId);
            return _mapper.Map<Chapter, ChapterModel>(chapter);
        }

        public ChapterModel GetNextChapter(int chapterId)
        {
            var chapter = _chapterRepository.GetById(chapterId);
            var nextChapter = _chapterRepository.GetByExpression(x => x.BookId == chapter.BookId && x.ChapterIndex == chapter.ChapterIndex + 1);
            if (nextChapter == null)
            {
                return _mapper.Map<Chapter, ChapterModel>(chapter);
            }
            return _mapper.Map<Chapter, ChapterModel>(nextChapter);
        }

        public ChapterModel GetPrevChapter(int chapterId)
        {
            var chapter = _chapterRepository.GetById(chapterId);
            var prevChapter = _chapterRepository.GetByExpression(x => x.BookId == chapter.BookId && x.ChapterIndex == chapter.ChapterIndex - 1);
            if (prevChapter == null)
            {
                return _mapper.Map<Chapter, ChapterModel>(chapter); 
            }
            return _mapper.Map<Chapter, ChapterModel>(prevChapter);
        }

        public void CreateChapter(ChapterModel chapter)
        {
            _chapterRepository.Insert(_mapper.Map<ChapterModel, Chapter>(chapter));
            _chapterRepository.Save();
        }
        public void UpdateChapter(ChapterModel chapter)
        {
            _chapterRepository.Update(_mapper.Map<ChapterModel, Chapter>(chapter));
            _chapterRepository.Save();
        }

        public void DeleteChapter(int chapterId)
        {
            _chapterRepository.Delete(chapterId);
            _chapterRepository.Save();
        }

    }
}
