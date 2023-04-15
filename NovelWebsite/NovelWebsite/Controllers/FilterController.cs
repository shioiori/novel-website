using Microsoft.AspNetCore.Mvc;
using NovelWebsite.Entities;
using NovelWebsite.Models;
using Microsoft.EntityFrameworkCore;

namespace NovelWebsite.Controllers
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
            var query = _dbContext.Books.Where(b => filterModel.CategoryId == 0 || b.CategoryId == filterModel.CategoryId)
                                        .Include(b => b.Author)
                                        .Include(b => b.BookStatus)
                                        .Where(b => b.IsDeleted == false)
                                        .ToList();
            var final = query;
            // lọc theo tình trạng
            if (filterModel.BookStatus != null)
            {
                var f1 = query.Where(b => b.BookStatusId == filterModel.BookStatus[0]).ToList();
                for (int i = 1; i < filterModel.BookStatus.Count(); i++)
                {
                    var temp = query.Where(b => b.BookStatusId == filterModel.BookStatus[i]);
                    foreach (var item in temp)
                    {
                        f1.Add(item);
                    }
                }
                final = f1;
            }

            // lọc theo xếp hạng
            if (!string.IsNullOrEmpty(filterModel.Rank))
            {
                var f2 = final;
                switch (filterModel.Rank)
                {
                    case "view":
                        f2 = f2.OrderByDescending(b => b.Views).ToList();
                        break;
                    case "like":
                        f2 = f2.OrderByDescending(b => b.Likes).ToList();
                        break;
                    case "recommend":
                        f2 = f2.OrderByDescending(b => b.Recommends).ToList();
                        break;
                    case "follow":
                        var mostFollow = _dbContext.BookUserFollows
                                        .GroupBy(bu => bu.BookId)
                                        .OrderByDescending(g => g.Count())
                                        .Select(g => g.Key)
                                        .ToList();
                        f2 = f2.OrderBy(b => {
                                                var index = mostFollow.IndexOf(b.BookId);
                                                return index == -1 ? mostFollow.Count : index;
                                            }).ToList();
                        break;
                    case "comment":
                        var mostComment = _dbContext.Comments
                                        .GroupBy(bu => bu.BookId)
                                        .OrderByDescending(g => g.Count())
                                        .Select(g => g.Key)
                                        .ToList();
                        f2 = f2.OrderBy(b => {
                            var index = mostComment.IndexOf(b.BookId);
                            return index == -1 ? mostComment.Count : index;
                        }).ToList();
                        break;
                    default:
                        f2 = f2.OrderByDescending(b => b.CreatedDate).ToList();
                        break;
                }
                final = f2;
            }

            // lọc theo số chương
            if (filterModel.ChapterRange != null)
            {
                var f3 = final;
                int minRange = filterModel.ChapterRange[0];
                f3 = f3.Where(b => b.NumberOfChapters <= filterModel.ChapterRange[0]).ToList();
                for (int i = 1; i < filterModel.ChapterRange.Count(); i++)
                {
                    var temp = final.Where(b => b.NumberOfChapters <= filterModel.ChapterRange[i] && b.NumberOfChapters > minRange);
                    minRange = filterModel.ChapterRange[i];
                    foreach (var item in temp)
                    {
                        f3.Add(item);
                    }
                }
                final = f3;
            }
            // sắp xếp

            if (!string.IsNullOrEmpty(filterModel.OrderBy))
            {
                var f4 = final;
                switch (filterModel.OrderBy)
                {
                    case "new":
                        f4 = f4.OrderByDescending(b => b.CreatedDate).ToList();
                        break;
                    case "old":
                        f4 = f4.OrderBy(b => b.CreatedDate).ToList();
                        break;
                }
                final = f4;
            }

            // lọc theo tag
            // kiểm tra tag của những quyển đã có -> tag nào k có thì remove khỏi ds
            if (filterModel.Tag != null)
            {
                var f5 = new List<BookEntity>(final);
                foreach (var item in final)
                {
                    var temp = _dbContext.BookTags.Where(b => b.BookId == item.BookId).Select(b => b.TagId).ToList();
                    if (temp.Count == 0)
                    {
                        f5.Remove(item);
                        continue;
                    }
                    foreach (var tag in filterModel.Tag)
                    {
                        if (!temp.Contains(tag))
                        {
                            f5.Remove(item);
                            break;
                        }
                    }
                }
                final = f5;
            }

            ViewBag.pageNumber = pageNumber;
            ViewBag.pageSize = pageSize;
            ViewBag.pageCount = Math.Ceiling(final.Count() * 1.0 / pageSize);

            return View(final.Skip(pageSize * pageNumber - pageSize)
                         .Take(pageSize)
                         .ToList());
        }

        [Route("{action}")]

        public IActionResult GetBookStatuses()
        {
            return Json(_dbContext.BookStatuses.ToList());
        }

        [Route("{action}")]

        public IActionResult GetAllTags()
        {
            return Json(_dbContext.Tags.ToList());
        }

    }
}
