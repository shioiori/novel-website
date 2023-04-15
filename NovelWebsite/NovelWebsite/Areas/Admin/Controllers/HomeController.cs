using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NovelWebsite.Entities;
using NovelWebsite.Models;
using System.Linq;

namespace NovelWebsite.Areas.Controllers
{
    [Area("Admin")]
    [Authorize (Roles = "Admin, Biên tập viên")]
    public class HomeController : Controller
    {
        private readonly AppDbContext _dbContext;

        public HomeController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            ViewBag.NumberOfUsers = _dbContext.Users.Count();
            ViewBag.NumberOfBooks = _dbContext.Books.Count();
            ViewBag.NumberOfFinishedBooks = _dbContext.Books.Count(x => x.BookStatusId == "HOANTHANH");
            ViewBag.NumberOfChapters = _dbContext.Chapters.Count();
            ViewBag.NumberOfComments = _dbContext.Comments.Count();
            ViewBag.NumberOfReviews = _dbContext.Reviews.Count();
            return View();
        }

        public IActionResult UploadChapterMonthlyReport()
        {
            // Linq query to get the count of chapters created each month
            var result = from chapter in _dbContext.Chapters
                         group chapter by new { chapter.UpdatedDate.Year, chapter.UpdatedDate.Month } into g
                         orderby g.Key.Year, g.Key.Month
                         select new
                         {
                             Month = g.Key.Month,
                             Year = g.Key.Year,
                             Count = g.Count()
                         };
            // List of chapter count by month
            List<int> chapterCountByMonth = new List<int>();

            // Fill list with counts for each month (if there is no chapter, add 0)
            for (int i = 1; i <= 12; i++)
            {
                var count = result.FirstOrDefault(x => x.Month == i && x.Year == DateTime.Now.Year)?.Count ?? 0;
                chapterCountByMonth.Add(count);
            }
            return Json(chapterCountByMonth);
        }
    }
}
