using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NovelWebsite.Entities;
using NovelWebsite.Models;
using System.Security.Claims;

namespace NovelWebsite.Controllers
{
    [Route("/ho-so")]
    [Route("/{controller}")]
    public class UserController : Controller
    {
        private readonly AppDbContext _dbContext;

        public UserController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [Authorize(Policy = "UserIdentity")]
        [Route("{userid?}")]
        public IActionResult Profile(int userId = 0)
        {
            if (userId != 0)
            {
                var user = _dbContext.Users.FirstOrDefault(x => x.UserId == userId);
                return View(user);
            }
            var claims = HttpContext.User.Identity as ClaimsIdentity;
            var user2 = _dbContext.Users.Where(a => a.UserId == Int32.Parse(claims.FindFirst("UserId").Value))
                                                .FirstOrDefault();
            return View(user2);
        }

        [HttpPost]
        [Route("{action}")]
        public IActionResult UpdateProfile(UserModel userModel)
        {
            if (!ModelState.IsValid)
            {
                TempData["error"] = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).First();
            }
            else
            {
                var user = _dbContext.Users.FirstOrDefault(u => u.UserId == userModel.UserId);
                user.UserName = userModel.Username;
                user.Email = userModel.Email;
                _dbContext.Users.Update(user);
                _dbContext.SaveChanges();
            }
            return Redirect($"/ho-so/{userModel.UserId}");
        }

        [Route("{action}")]
        public IActionResult UpdateAvatar(int userId, string avatar)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.UserId == userId);
            user.Avatar = avatar;
            _dbContext.Users.Update(user);
            _dbContext.SaveChanges();
            return Json(avatar);
        }

        [Route("{action}")]
        public IActionResult UpdateCoverPhoto(int userId, string coverPhoto)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.UserId == userId);
            user.CoverPhoto = coverPhoto;
            _dbContext.Users.Update(user);
            _dbContext.SaveChanges();
            return Json(coverPhoto);
        }

        [Route("{id}/tu-truyen")]
        public IActionResult Bookshelf(int id, int pageNumber = 1, int pageSize = 10)
        {
            var books = _dbContext.BookUserFollows.Where(x => x.UserId == id).ToList();
            var all = _dbContext.Books.Where(x => x.Status == 0 && x.IsDeleted == false).Include(b => b.Author).ToList();
            var bookshelf = new List<BookEntity>();
            foreach (var item in books)
            {
                bookshelf.Add(all.FirstOrDefault(x => x.BookId == item.BookId));
            }

            ViewBag.pageNumber = pageNumber;
            ViewBag.pageSize = pageSize;
            ViewBag.pageCount = Math.Ceiling(bookshelf.Count() * 1.0 / pageSize);
            ViewBag.UserId = id;

            return View(bookshelf.Skip(pageSize * pageNumber - pageSize)
                         .Take(pageSize)
                         .ToList());
        }

        [Route("{id}/truyen-da-dang")]
        public IActionResult BookUpload(int id, int pageNumber = 1, int pageSize = 10)
        {
            var books = _dbContext.Books.Where(x => x.UserId == id && x.IsDeleted == false)
                                        .Include(b => b.Author)
                                        .Include(b => b.BookStatus)
                                        .Include(b => b.User)
                                        .ToList();

            ViewBag.pageNumber = pageNumber;
            ViewBag.pageSize = pageSize;
            ViewBag.pageCount = Math.Ceiling(books.Count() * 1.0 / pageSize);
            ViewBag.UserId = id;

            return View(books.Skip(pageSize * pageNumber - pageSize)
                         .Take(pageSize)
                         .ToList());
        }

        [Authorize(Policy = "BookOwner")]
        [Route("/dang-tai/{userId}/truyen/{bookId}/danh-sach-chuong")]
        public IActionResult ListOfChapters(int bookId, int pageNumber = 1, int pageSize = 16)
        {
            var query = _dbContext.Chapters.Where(b => b.BookId == bookId && b.IsDeleted == false)
                                        .Where(c => c.IsDeleted == false)
                                        .OrderBy(b => b.CreatedDate)
                                        .ToList();
            ViewBag.pageNumber = pageNumber;
            ViewBag.pageSize = pageSize;
            ViewBag.pageCount = Math.Ceiling(query.Count() * 1.0 / pageSize);
            var claims = HttpContext.User.Identity as ClaimsIdentity;
            ViewBag.userId = Int32.Parse(claims.FindFirst("UserId").Value);
            ViewBag.bookId = bookId;

            return View(query.Skip(pageSize * pageNumber - pageSize)
                         .Take(pageSize)
                         .ToList());
        }
    }
}
