using Microsoft.AspNetCore.Mvc;
using NovelWebsite.Entities;
using Microsoft.EntityFrameworkCore;
using NovelWebsite.Models;
using Microsoft.AspNetCore.Authorization;
using X.PagedList;

namespace NovelWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin, Biên tập viên")]
    [Route("/Admin/Book")]
    public class BookController : Controller
    {
        private readonly AppDbContext _dbContext;

        public BookController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [Route("ListOfBooks")]
        public IActionResult ListOfBooks(string? name, int pageNumber = 1, int pageSize = 10)
        {
            var query = _dbContext.Books.Where(b => string.IsNullOrEmpty(name) || b.BookName.ToLower().Contains(name.ToLower()))
                                        .Where(b => b.IsDeleted == false)
                                        .Include(b => b.Author)
                                        .Include(b => b.Category)
                                        .Include(b => b.User)
                                        .Include(b => b.BookStatus)
                                        .OrderByDescending(b => b.CreatedDate)
                                        .ToList();

            ViewBag.searchName = name;
            PagedList<BookEntity> listBook = new PagedList<BookEntity>(query, pageNumber, pageSize);
            return View(listBook);
        }
        
        public IActionResult AddOrUpdateBook(int id = 0)
        {
            if (id == 0)
            {
                return View();
            }
            var query = _dbContext.Books.Where(b => b.BookId == id && b.IsDeleted == false)
                                         .Include(b => b.Author)
                                         .Include(b => b.Category)
                                         .Include(b => b.User)
                                         .Include(b => b.BookStatus)
                                         .First();
            if (query == null)
            {
                return NotFound();
            }
            return View(query);
        }

        [Route("DeleteBook/{bookId}")]
        public IActionResult DeleteBook(int bookId)
        {
            var book = _dbContext.Books.First(x => x.BookId == bookId);
            book.IsDeleted = true;
            _dbContext.Books.Update(book);
            _dbContext.SaveChanges();
            return Redirect("/Admin/Book/ListOfBooks");
        }
    }
}
