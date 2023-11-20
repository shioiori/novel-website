using AutoMapper;
using NovelWebsite.NovelWebsite.Infrastructure.Entities;
using NovelWebsite.NovelWebsite.Core.Enums;
using NovelWebsite.NovelWebsite.Core.Interfaces.Repositories;
using NovelWebsite.NovelWebsite.Core.Interfaces.Services;
using NovelWebsite.NovelWebsite.Core.Models;

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

        public IEnumerable<ChapterModel> GetChapters(string bookId)
        {
            var chapters = _chapterRepository.Filter(x => x.BookId == bookId);
            return _mapper.Map<IEnumerable<Chapter>, IEnumerable<ChapterModel>>(chapters);
        }

        public IEnumerable<ChapterModel> GetChaptersByStatus(string bookId, UploadStatus uploadStatus)
        {
            var chapters = _chapterRepository.Filter(x => x.BookId == bookId && x.Status == (int)uploadStatus);
            return _mapper.Map<IEnumerable<Chapter>, IEnumerable<ChapterModel>>(chapters);
        }

        public ChapterModel GetChapter(string chapterId)
        {
            var chapter = _chapterRepository.GetById(chapterId);
            return _mapper.Map<Chapter, ChapterModel>(chapter);
        }

        public ChapterModel GetChapter(string bookId, int chapterIndex)
        {
            var chapter = _chapterRepository.GetByExpression(x => x.BookId == bookId && x.ChapterIndex == chapterIndex);
            return _mapper.Map<Chapter, ChapterModel>(chapter);
        }
        public ChapterModel GetNextChapter(string chapterId)
        {
            var chapter = _chapterRepository.GetById(chapterId);
            var nextChapter = _chapterRepository.GetByExpression(x => x.BookId == chapter.BookId && x.ChapterIndex == chapter.ChapterIndex + 1);
            if (nextChapter == null)
            {
                return _mapper.Map<Chapter, ChapterModel>(chapter);
            }
            return _mapper.Map<Chapter, ChapterModel>(nextChapter);
        }

        public ChapterModel GetPrevChapter(string chapterId)
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
            if (chapter.ChapterNumber == 0)
            {
                var count = _chapterRepository.Filter(x => x.BookId == chapter.BookId).Count();
                chapter.ChapterNumber = count + 1;
            }
            _chapterRepository.Insert(_mapper.Map<ChapterModel, Chapter>(chapter));
            _chapterRepository.Save();
        }
        public void UpdateChapter(ChapterModel chapter)
        {
            _chapterRepository.Update(_mapper.Map<ChapterModel, Chapter>(chapter));
            _chapterRepository.Save();
        }

        public void DeleteChapter(string chapterId)
        {
            _chapterRepository.Delete(chapterId);
            _chapterRepository.Save();
        }

    }
}
