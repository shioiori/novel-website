using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NovelWebsite.Entities;
using NovelWebsite.Models;
using X.PagedList;

namespace NovelWebsite.Controllers
{
    [Route("/bang-xep-hang")]
    [Route("/{controller}")]
    public class BillboardController : Controller
    {
        private readonly AppDbContext _dbContext;

        public BillboardController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [Route("")]
        public IActionResult Index(string? sort_by, string? order, int category_id = 0, int pageNumber = 1, int pageSize = 20)
        {
            var query = _dbContext.Books.Where(b => b.Status == 0 && b.IsDeleted == false)
                                        .Where(b => category_id == 0 || b.CategoryId == category_id)
                                        .Include(b => b.Author)
                                        .Include(b => b.Category)
                                        .Include(b => b.User)
                                        .Include(b => b.BookStatus)
                                        .OrderByDescending(b => b.CreatedDate).ToList();
            if (!string.IsNullOrEmpty(order))
            {
                if (order == "up")
                {
                    query = query.OrderBy(b => b.CreatedDate).ToList();
                }
            }

            if (!string.IsNullOrEmpty(sort_by))
            {
                switch (sort_by)
                {
                    case "view":
                        query = query.OrderByDescending(b => b.Views).ToList();
                        break;
                    case "like":
                        query = query.OrderByDescending(b => b.Likes).ToList();
                        break;
                    case "follow":
                        var mostFollow = _dbContext.BookUserFollows
                                        .GroupBy(bu => bu.BookId)
                                        .OrderByDescending(g => g.Count())
                                        .Select(g => g.Key)
                                        .ToList();
                        query = query.OrderBy(b => {
                            var index = mostFollow.IndexOf(b.BookId);
                            return index == -1 ? mostFollow.Count : index;
                        }).ToList();
                        break;
                    case "recommend":
                        query = query.OrderByDescending(b => b.Recommends).ToList();
                        break;
                }
            }

            ViewBag.categoryId = category_id;
            ViewBag.sortBy = sort_by;
            ViewBag.order = order;
            ViewBag.category = _dbContext.Categories.ToList();

            PagedList<BookEntity> listBook = new PagedList<BookEntity>(query, pageNumber, pageSize);

            return View(listBook);
        }

    }
}
