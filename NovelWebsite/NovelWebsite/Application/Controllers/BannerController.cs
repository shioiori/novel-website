using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NovelWebsite.Infrastructure.Contexts;

namespace NovelWebsite.Application.Controllers
{
    public class BannerController : Controller
    {
        private readonly AppDbContext _dbContext;
        public BannerController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult GetMainBanner(int number = 3)
        {
            var query = _dbContext.Banners.Where(b => b.BannerSize == "L").Include(b => b.Book).ToList();
            return Json(query);
        }

        public IActionResult GetAdsBanner()
        {
            var query = _dbContext.Banners.Where(b => b.BannerSize == "S").Include(b => b.Book).ToList();
            return Json(query);
        }
    }
}
