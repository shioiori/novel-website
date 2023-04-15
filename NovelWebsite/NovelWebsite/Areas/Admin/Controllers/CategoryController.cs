using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NovelWebsite.Entities;
using NovelWebsite.Extensions;
using NovelWebsite.Models;

namespace NovelWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin, Biên tập viên")]
    public class CategoryController : Controller
    {
        private readonly AppDbContext _dbContext;

        public CategoryController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index(int pageNumber = 1, int pageSize = 10)
        {
            var query = _dbContext.Categories.Skip(pageSize * pageNumber - pageSize)
                                             .Take(pageSize)
                                             .ToList(); 

            ViewBag.pageNumber = pageNumber;
            ViewBag.pageSize = pageSize;
            ViewBag.pageCount = Math.Ceiling(_dbContext.Categories.Count() * 1.0 / pageSize);
            
            return View(query);
        }

        [HttpPost]
        public IActionResult AddOrUpdateCategory(CategoryModel category)
        {
            var cat = _dbContext.Categories.Where(c => c.CategoryId == category.CategoryId).FirstOrDefault();
            if (cat == null)
            {
                _dbContext.Categories.Add(new CategoryEntity()
                {
                    CategoryId = category.CategoryId,
                    CategoryName = category.CategoryName,
                    CategoryImage = category.CategoryImage,
                    Quantity = 0,
                    Slug = StringExtension.Slugify(category.CategoryName),
                });
            }
            else
            {
                cat.CategoryName = category.CategoryName;
                cat.CategoryImage = category.CategoryImage;
                cat.Slug = StringExtension.Slugify(category.CategoryName);
            }
            _dbContext.SaveChanges();
            return Redirect("/Admin/Category/Index");
        }

        public IActionResult AddOrUpdateCategory(int id)
        {
            var category = _dbContext.Categories.FirstOrDefault(x => x.CategoryId == id);
            if (category == null)
            {
                return Json("");
            }
            return Json(category);
        }

        public IActionResult DeleteCategory(int id)
        {
            var category = _dbContext.Categories.FirstOrDefault(x => x.CategoryId == id);
            if (category != null)
            {
                _dbContext.Categories.Remove(category);
                _dbContext.SaveChanges();
            }
            return Redirect("/Admin/Category/Index");
        }
    }
}
