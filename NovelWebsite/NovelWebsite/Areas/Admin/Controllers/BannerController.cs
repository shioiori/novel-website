using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NovelWebsite.Entities;

namespace NovelWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin, Biên tập viên")]
    public class BannerController : Controller
    {
        private readonly AppDbContext _dbContext;
        public BannerController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index(int pageNumber = 1, int pageSize = 10)
        {
            var query = _dbContext.Banners.Include(b => b.Book).ToList();

            ViewBag.pageNumber = pageNumber;
            ViewBag.pageSize = pageSize;
            ViewBag.pageCount = Math.Ceiling(_dbContext.Banners.Count() * 1.0 / pageSize);

            ViewBag.Books = new SelectList(_dbContext.Books.ToList(), "BookId", "BookName");

            return View(query.Skip(pageSize * pageNumber - pageSize)
                                             .Take(pageSize)
                                             .ToList());
        }

        public IActionResult AddOrUpdateBanner(int id)
        {
            var banner = _dbContext.Banners.FirstOrDefault(x => x.BannerId == id);
            if (banner == null)
            {
                return Json("");
            }
            return Json(banner);
        }

        [HttpPost]
        public IActionResult AddOrUpdateBanner(BannerEntity banner)
        {
            var cat = _dbContext.Banners.Where(c => c.BannerId == banner.BannerId).FirstOrDefault();
            if (cat == null)
            {
                banner.CreatedDate = DateTime.Now;
                banner.UpdatedDate = DateTime.Now;
                banner.Status = 0;
                banner.IsDeleted = false;
                _dbContext.Banners.Add(banner);
            }
            else
            {
                cat.BannerSize = banner.BannerSize;
                cat.BannerImage = banner.BannerImage;
                if (banner.BookId != null)
                {
                    cat.BookId = banner.BookId;
                }
                cat.UpdatedDate = DateTime.Now;
                _dbContext.Banners.Update(cat);
            }
            _dbContext.SaveChanges();
            return Redirect("/Admin/Banner/Index");
        }

        public IActionResult DeleteBanner(int id)
        {
            var banner = _dbContext.Banners.FirstOrDefault(x => x.BannerId == id);
            if (banner != null)
            {
                _dbContext.Banners.Remove(banner);
                _dbContext.SaveChanges();
            }
            return Redirect("/Admin/Banner/Index");
        }
    }
}
