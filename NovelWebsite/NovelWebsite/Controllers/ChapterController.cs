using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using NovelWebsite.Entities;

namespace NovelWebsite.Controllers
{
    
    [Route("/truyen")]
    [Route("/{controller}")]
    public class ChapterController : Controller
    {
        private readonly AppDbContext _dbContext;
        private readonly IMemoryCache _cache;

        public ChapterController(AppDbContext dbContext, IMemoryCache cache)
        {
            _dbContext = dbContext;
            _cache = cache;
        }

        public int UpdateViewCount(int id, int views)
        {
            var str = "chapter-" + id.ToString();
            if (_cache.TryGetValue("cache_keys", out List<string> cachedList))
            {
                cachedList.Add(str);
                _cache.Set("cache_keys", cachedList, TimeSpan.FromMinutes(30));
            }
            else
            {
                var list = new List<String>();
                list.Add(str);
                _cache.Set("cache_keys", list, TimeSpan.FromMinutes(30));
            }
            var currentViewCount = _cache.Get<int>(str);
            if (currentViewCount == 0)
            {
                _cache.Set(str, views);
                currentViewCount = views;
            }
            _cache.Set(str, currentViewCount + 1);
            return currentViewCount + 1;
        }

        [Route("{slug}-{id:int}/chuong-{chapterNumber:int}/{chapterSlug}-{chapterId:int}")]
        public IActionResult Index(int chapterId)
        {
            var chapter = _dbContext.Chapters.Where(c => c.IsDeleted == false)
                                             .Where(c => c.ChapterId == chapterId)
                                             .Include(c => c.Book)
                                             .ThenInclude(b => b.Author)
                                             .FirstOrDefault();
            ViewBag.prevChapter = _dbContext.Chapters.Where(c => c.BookId == chapter.BookId && c.ChapterNumber == chapter.ChapterNumber - 1).FirstOrDefault();
            ViewBag.nextChapter = _dbContext.Chapters.Where(c => c.BookId == chapter.BookId && c.ChapterNumber == chapter.ChapterNumber + 1).FirstOrDefault();
            ViewBag.bookLink = $"/truyen/{chapter.Book.Slug}-{chapter.BookId}/";
            return View(chapter);
        }
        [Route("{action}")]
        public IActionResult GetAllCategories()
        {
            var query = _dbContext.Categories.ToList();
            return Json(query);
        }
        [Route("{action}")]
        public IActionResult GetListComments(int id)
        {
            var listComment = _dbContext.Comments.Where(c => c.Chapter.ChapterId == id).Include("User").OrderByDescending(c => c.CreatedDate).ToList();
            return Json(listComment);
        }

        [Route("{action}")]
        public IActionResult GetListChapters(int id)
        {
            var listChapters = _dbContext.Chapters.Where(c => c.IsDeleted == false)
                                                  .Where(c => c.BookId == id)
                                                  .OrderBy(c => c.CreatedDate)
                                                  .ToList();
            return Json(listChapters);
        }

        [Route("{action}")]
        public IActionResult DeleteChapter(int chapterId)
        {
            var chapter = _dbContext.Chapters.FirstOrDefault(x => x.ChapterId == chapterId);
            chapter.IsDeleted = true;
            _dbContext.Chapters.Update(chapter);
            _dbContext.SaveChanges();
            return Json("");
        }
    }
}
