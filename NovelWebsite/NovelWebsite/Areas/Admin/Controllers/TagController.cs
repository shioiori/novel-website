using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NovelWebsite.Entities;
using NovelWebsite.Extensions;
using NovelWebsite.Models;

namespace NovelWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin, Biên tập viên")]
    public class TagController : Controller
    {
        private readonly AppDbContext _dbContext;

        public TagController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index(string? name, int pageNumber = 1, int pageSize = 10)
        {
            var query = _dbContext.Tags.Where(t => string.IsNullOrEmpty(name) || t.TagName.ToLower().Trim().Contains(name.ToLower().Trim()));
                                       
            ViewBag.pageNumber = pageNumber;
            ViewBag.pageSize = pageSize;    
            ViewBag.pageCount = Math.Ceiling(query.Count() * 1.0 / pageSize);
            ViewBag.searchName = name;

            return View(query.Skip(pageSize * pageNumber - pageSize)
                         .Take(pageSize)
                         .ToList());
        }

        [HttpPost]
        public IActionResult AddOrUpdateTag(TagModel tag)
        {
            var t = _dbContext.Tags.Where(t => t.TagId == tag.TagId).FirstOrDefault();
            if (t == null)
            {
                _dbContext.Tags.Add(new TagEntity()
                {
                    TagId = tag.TagId,
                    TagName = tag.TagName,
                    Slug = StringExtension.Slugify(tag.TagName),
                });
            }
            else
            {
                t.TagName = tag.TagName;
                t.Slug = StringExtension.Slugify(tag.TagName);
                _dbContext.Tags.Update(t);
            }
            _dbContext.SaveChanges();
            return Redirect("/Admin/Tag/Index");
        }

        public IActionResult AddOrUpdateTag(int id)
        {
            var tag = _dbContext.Tags.Where(t => t.TagId == id).FirstOrDefault();
            if (tag == null)
            {
                return Json("");
            }
            return Json(tag);
        }

        [HttpDelete]
        public IActionResult DeleteTag(int id)
        {
            var tag = _dbContext.Tags.Where(t => t.TagId == id).FirstOrDefault();
            if (tag != null)
            {
                _dbContext.Tags.Remove(tag);
                _dbContext.SaveChanges();
            }
            return Redirect("/Admin/Tag/Index");
        }
    }
}
