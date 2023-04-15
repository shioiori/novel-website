using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using NovelWebsite.Entities;
using NovelWebsite.Extensions;
using NovelWebsite.Models;

namespace NovelWebsite.Controllers
{   
    [Route("/truyen")]
    [Route("/{controller}")]
    public class BookController : Controller
    {
        private readonly AppDbContext _dbContext;
        private readonly IMemoryCache _cache;

        public BookController(AppDbContext dbContext, IMemoryCache cache)
        {
            _dbContext = dbContext;
            _cache = cache;
        }

        public int UpdateViewCount(int id, int views)
        {
            var str = "book-" + id.ToString();
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

        [Route("{slug}-{id:int}")]
        public IActionResult Index(int id)
        {
            var book = _dbContext.Books.Where(b => b.BookId == id)
                                       .Include(b => b.Author)
                                       .Include(b => b.BookStatus)
                                       .Include(b => b.User)
                                       .Include(b => b.Category)
                                       .FirstOrDefault();
            ViewBag.firstChapter = _dbContext.Chapters.Where(x => x.BookId == id && x.ChapterNumber == 1).FirstOrDefault();
            ViewData["Views"] = UpdateViewCount(book.BookId, (int)book.Views);
            return View(book);
        }

        [Route("{action}")]
        public IActionResult GetListChapters(int id)
        {
            var listChapters = _dbContext.Chapters.Where(c => c.Book.BookId == id).OrderBy(c => c.CreatedDate).ToList();
            return Json(listChapters);
        }

        [Route("{action}")]
        public IActionResult GetListReviews(int id)
        {
            var listReviews = _dbContext.Reviews.Where(r => r.Book.BookId == id).Include("User").OrderByDescending(r => r.CreatedDate).ToList();
            return Json(listReviews);
        }

        [Route("{action}")]
        public IActionResult GetListComments(int id)
        {
            var listComment = _dbContext.Comments.Where(c => c.Book.BookId == id).Include("User").OrderByDescending(c => c.CreatedDate).ToList();
            return Json(listComment);
        }

        [Route("{action}")]
        public IActionResult GetAuthorBooks(int id, int number = 6)
        {
            var listAuthorBooks = _dbContext.Books.Where(b => b.Author.AuthorId == id).OrderByDescending(b => b.CreatedDate).Take(number).ToList();
            return Json(listAuthorBooks);
        }

        [Route("{action}")]
        public IActionResult GetUserBooks(int id, int number = 6)
        {
            var user = _dbContext.Books.Where(b => b.UserId == id).OrderByDescending(b => b.CreatedDate).Take(number).ToList();
            return Json(user);
        }

        [Route("{action}")]
        public IActionResult BooksMaybeYouLike(int id, int number = 6)
        {
            var listBooks = _dbContext.Books.Include(b => b.Category).Where(b => b.Category.CategoryId == id).Include("Author").OrderByDescending(b => b.CreatedDate).Take(number).ToList();
            return Json(listBooks);
        }

        [Route("{action}")]
        public IActionResult GetBookTags(int id)
        {
            var bookTag = _dbContext.BookTags.Where(x => x.BookId == id).Select(x => x.TagId).ToList();
            var tags = _dbContext.Tags.ToList();
            List<TagEntity> listTag = new List<TagEntity>();
            foreach (var item in tags)
            {
                if (bookTag.Contains(item.TagId))
                {
                    listTag.Add(item);
                }
            }
            return Json(listTag);
        }
    }
}
