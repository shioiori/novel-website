using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NovelWebsite.Entities;
using NovelWebsite.Extensions;
using NovelWebsite.Models;
using X.PagedList;

namespace NovelWebsite.Controllers
{
    public class ReviewController : Controller
    {
        private readonly AppDbContext _dbContext;

        public ReviewController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index(string? sort_by, int categoryId = 0, int pageNumber = 1, int pageSize = 8)
        {
            var reviews = _dbContext.Reviews.Include(r => r.Book).ThenInclude(b => b.Author)
                                            .Where(r => categoryId == 0 || r.Book.CategoryId == categoryId)
                                            .Include(b => b.User)
                                            .OrderByDescending(r => r.CreatedDate).ToList();
            if (sort_by != null)
            {
                if (sort_by == "up")
                {
                    reviews = reviews.OrderBy(r => r.CreatedDate).ToList();
                }
            }

            ViewBag.categoryId = categoryId;
            ViewBag.sortBy = sort_by;
            ViewBag.category = _dbContext.Categories.ToList();

            PagedList<ReviewEntity> listReview = new PagedList<ReviewEntity>(reviews, pageNumber, pageSize);

            return View(listReview);            
        }

        [HttpPost]
        public IActionResult AddReview(ReviewModel review)
        {
            var rv = new ReviewEntity()
            {
                BookId = review.BookId,
                UserId = review.UserId,
                Content = StringExtension.HtmlEncode(review.Content),
                Likes = 0,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                Status = 0,
                IsDeleted = false
            };
            _dbContext.Reviews.Add(rv);
            _dbContext.SaveChanges();
            return NoContent();
        }
    }
}
