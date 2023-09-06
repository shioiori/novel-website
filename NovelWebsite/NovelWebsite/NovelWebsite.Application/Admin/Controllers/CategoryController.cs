using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NovelWebsite.Infrastructure.Contexts;
using NovelWebsite.Infrastructure.Entities;
using NovelWebsite.NovelWebsite.Core.Models;
using NovelWebsite.NovelWebsite.Domain.Services;
using NovelWebsite.NovelWebsite.Domain.Utils;

namespace NovelWebsite.NovelWebsite.Application.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin, Biên tập viên")]
    public class CategoryController : Controller
    {
        private ICategoryService _service;

        public CategoryController(ICategoryService service)
        {
            _service = service;
        }
        public IActionResult Index(int pageNumber = 1, int pageSize = 10)
        {
            var categories = _service.GetAllCategories();

            // ViewBag.pageNumber = pageNumber;
            // ViewBag.pageSize = pageSize;
            // ViewBag.pageCount = Math.Ceiling(_dbContext.Categories.Count() * 1.0 / pageSize);

            return View(categories);
        }

        [HttpPost]
        public IActionResult AddOrUpdateCategory(CategoryModel category)
        {
            var cat = _dbContext.Categories.Where(c => c.CategoryId == category.CategoryId).FirstOrDefault();
            if (cat == null)
            {
                _dbContext.Categories.Add(new Category()
                {
                    CategoryId = category.CategoryId,
                    CategoryName = category.CategoryName,
                    CategoryImage = category.CategoryImage,
                    Quantity = 0,
                    Slug = SlugifyUtil.Slugify(category.CategoryName),
                });
            }
            else
            {
                cat.CategoryName = category.CategoryName;
                cat.CategoryImage = category.CategoryImage;
                cat.Slug = SlugifyUtil.Slugify(category.CategoryName);
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
