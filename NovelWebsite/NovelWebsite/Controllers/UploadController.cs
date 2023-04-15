using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NovelWebsite.Extensions;
using NovelWebsite.Models;
using System.Security.Claims;

namespace NovelWebsite.Entities
{
    [Route("/dang-tai")]
    [Route("/{controller}")]
    public class UploadController : Controller
    {
        private readonly AppDbContext _dbContext;

        public UploadController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [Authorize(Policy = "UserIdentity")]
        [Authorize(Policy = "BookOwner")]
        [Route("{userId}/truyen/{bookId?}")]
        public IActionResult AddOrUpdateBook(int bookId = 0)
        {
            var book = _dbContext.Books.Where(b => b.Status == 0 && b.IsDeleted == false && b.BookId == bookId)
                                       .Include(b => b.Author)
                                       .Include(b => b.Category)
                                       .FirstOrDefault();
            ViewBag.Tags = _dbContext.Tags.ToList();
            ViewBag.CheckedTags = GetBookTags(bookId);
            ViewBag.BookStatuses = new SelectList(_dbContext.BookStatuses.ToList(), "BookStatusId", "BookStatusName");
            ViewBag.Categories = new SelectList(_dbContext.Categories.ToList(), "CategoryId", "CategoryName");
            ViewBag.UserId = book == null ? Int32.Parse(HttpContext.User.FindFirstValue("UserId"))  : book.UserId;
            if (book == null)
            {
                return View();
            }
            return View(book);
        }

        [HttpPost]
        [Route("{action}")]
        public IActionResult AddOrUpdateBook(BookModel bookModel)
        {
            if (!ModelState.IsValid)
            {
                TempData["error"] = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).First();
                if (bookModel.BookId == 0)
                {
                    return Redirect($"/dang-tai/{bookModel.UserId}/truyen/");
                }
                return Redirect($"/dang-tai/{bookModel.UserId}/truyen/" + bookModel.BookId);
            }
            else
            {
                AuthorEntity author = _dbContext.Authors.FirstOrDefault(a => a.AuthorName == bookModel.AuthorName);
                if (author == null)
                {
                    author = new AuthorEntity()
                    {
                        AuthorName = bookModel.AuthorName,
                    };
                    _dbContext.Authors.Add(author);
                    _dbContext.SaveChanges();
                }
                var book = _dbContext.Books.FirstOrDefault(b => b.BookId == bookModel.BookId && b.IsDeleted == false);
                if (book == null)
                {
                    book = new BookEntity()
                    {
                        BookName = bookModel.BookName,
                        CategoryId = bookModel.CategoryId,
                        AuthorId = author.AuthorId,
                        UserId = Int32.Parse(HttpContext.User.FindFirstValue("UserId")),
                        NumberOfChapters = 0,
                        Views = 0,
                        Likes = 0,
                        Recommends = 0,
                        Avatar = bookModel.Avatar,
                        Introduce = StringExtension.HtmlEncode(bookModel.Introduce),
                        BookStatusId = bookModel.BookStatusId,
                        CreatedDate = DateTime.Now,
                        UpdatedDate = DateTime.Now,
                        Status = 0,
                        IsDeleted = false,
                        Slug = StringExtension.Slugify(bookModel.BookName)
                    };
                    _dbContext.Books.Add(book);
                }
                else
                {
                    book.BookName = bookModel.BookName;
                    book.AuthorId = author.AuthorId;
                    book.CategoryId = bookModel.CategoryId;
                    book.Avatar = bookModel.Avatar;
                    book.Introduce = StringExtension.HtmlEncode(bookModel.Introduce);
                    book.BookStatusId = bookModel.BookStatusId;
                    book.UpdatedDate = DateTime.Now;
                    book.Slug = StringExtension.Slugify(bookModel.BookName);
                    _dbContext.Books.Update(book);
                }
                _dbContext.SaveChanges();
                if (bookModel.Tag != null)
                {
                    AddTagsToBook(bookModel.Tag, book.BookId);
                }
                else
                {
                    var tag = _dbContext.BookTags.Where(x => x.BookId == book.BookId);
                    _dbContext.BookTags.RemoveRange(tag);
                    _dbContext.SaveChanges();
                }
                return Redirect($"/truyen/{book.Slug}-{book.BookId}");
            }
        }

        [Authorize(Policy = "UserIdentity")]
        [Authorize(Policy = "BookOwner")]
        [Route("{userId}/truyen/{bookId:int}/chuong/{chapterId?}")]
        public IActionResult AddOrUpdateChapter(int bookId, int chapterId = 0)
        {
            var chapter = _dbContext.Chapters.Where(b => b.Status == 0 && b.IsDeleted == false && b.ChapterId == chapterId).FirstOrDefault();
            ViewBag.ChapterNumber = chapter == null ? _dbContext.Chapters.Where(b => b.BookId == bookId).Count() + 1 : chapter.ChapterNumber;
            ViewBag.BookId = bookId;
            if (chapter == null)
            {
                return View();
            }
            return View(chapter);
        }

        [HttpPost]
        [Route("{action}")]
        public IActionResult AddOrUpdateChapter(ChapterModel chapterModel)
        {
            var claims = HttpContext.User.Identity as ClaimsIdentity;
            var userId = Int32.Parse(claims.FindFirst("UserId").Value);
            if (!ModelState.IsValid)
            {
                TempData["error"] = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).First();
                if (chapterModel.ChapterId != 0)
                {
                    return Redirect($"/dang-tai/{userId}/truyen/{chapterModel.BookId}/chuong/{chapterModel.ChapterId}");
                }
                return Redirect($"/dang-tai/{userId}/truyen/{chapterModel.BookId}/chuong");
            }
            var chapter = _dbContext.Chapters.FirstOrDefault(c => c.ChapterId == chapterModel.ChapterId && c.IsDeleted == false);
            if (chapter == null)
            {
                chapter = new ChapterEntity()
                {
                    ChapterName = chapterModel.ChapterName,
                    ChapterNumber = _dbContext.Chapters.Where(b => b.BookId == chapterModel.BookId).Count() + 1,
                    BookId = chapterModel.BookId,
                    Content = StringExtension.HtmlEncode(chapterModel.Content),
                    Views = 0,
                    Likes = 0,
                    Slug = StringExtension.Slugify(chapterModel.ChapterName),
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    Status = 0,
                    IsDeleted = false,
                };
                _dbContext.Chapters.Add(chapter);
            }
            else
            {
                chapter.ChapterName = chapterModel.ChapterName;
                chapter.Content = StringExtension.HtmlEncode(chapterModel.Content);
                chapter.UpdatedDate = DateTime.Now;
                chapter.Slug = StringExtension.Slugify(chapterModel.ChapterName);
                _dbContext.Chapters.Update(chapter);
            }
            _dbContext.SaveChanges();
            return Redirect($"/dang-tai/{userId}/truyen/{chapter.BookId}/danh-sach-chuong");
        }

        public IActionResult AddTagsToBook(List<int>listTag, int bookId)
        {
            // tag cũ không còn thì xoá
            var prevListTag = _dbContext.BookTags.Where(x => x.BookId == bookId);
            foreach (var item in prevListTag)
            {
                if (!listTag.Contains(item.TagId))
                {
                    _dbContext.BookTags.Remove(item);
                }
            }
            _dbContext.SaveChanges();

            // lấy lại list tag
            var currentListTag = _dbContext.BookTags.Where(x => x.BookId == bookId).Select(x => x.TagId).ToList();
            foreach (var item in listTag)
            {
                // không có trong db thì add vào
                if (!currentListTag.Contains(item))
                {
                    _dbContext.BookTags.Add(new BookTagEntity()
                    {
                        BookId = bookId,
                        TagId = item
                    });
                }
            }
            _dbContext.SaveChanges();
            return Json("200");
        }

        public List<TagEntity> GetBookTags(int id)
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
            return listTag;
        }
    }

}
