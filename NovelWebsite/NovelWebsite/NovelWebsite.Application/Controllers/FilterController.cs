using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NovelWebsite.Infrastructure.Entities;
using NovelWebsite.Infrastructure.Contexts;
using NovelWebsite.NovelWebsite.Core.Models;

namespace NovelWebsite.Application.Controllers
{
    [Route("/bo-loc")]
    [Route("/{controller}")]
    public class FilterController : Controller
    {
        private readonly AppDbContext _dbContext;

        public FilterController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [Route("{searchName?}")]
        [Route("{action}")]
        public IActionResult Index(string? searchName, int categoryId = 0, int pageNumber = 1, int pageSize = 10)
        {
            var query = _dbContext.Books.Where(b => b.Status == 0 && b.IsDeleted == false)
                                        .Where(b => string.IsNullOrEmpty(searchName) || b.BookName.ToLower().Trim().Contains(searchName.ToLower().Trim()))
                                        .Where(b => categoryId == 0 || b.CategoryId == categoryId)
                                        .Include(b => b.Author)
                                        .Include(b => b.BookStatus)
                                        .OrderByDescending(b => b.CreatedDate);

            ViewBag.pageNumber = pageNumber;
            ViewBag.pageSize = pageSize;
            ViewBag.pageCount = Math.Ceiling(query.Count() * 1.0 / pageSize);
            ViewBag.searchName = searchName;
            ViewBag.categoryId = categoryId;

            return View(query.Skip(pageSize * pageNumber - pageSize)
                         .Take(pageSize)
                         .ToList());
        }

        [Route("")]
        [Route("{action}")]
        [HttpPost]
        public IActionResult Index(FilterModel filterModel, int pageNumber = 1, int pageSize = 10)
        {
            // lọc theo thư mục
            var query = _dbContext.Books;

            return View(query);
        }

    }
}
