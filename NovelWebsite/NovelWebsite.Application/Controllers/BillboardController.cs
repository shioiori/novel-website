using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NovelWebsite.Infrastructure.Contexts;
using NovelWebsite.Infrastructure.Entities;
using NovelWebsite.NovelWebsite.Core.Enums;
using NovelWebsite.NovelWebsite.Core.Interfaces;
using NovelWebsite.NovelWebsite.Core.Interfaces.Services;
using NovelWebsite.NovelWebsite.Domain.Services;
using X.PagedList;

namespace NovelWebsite.Application.Controllers
{
    [Route("/bang-xep-hang")]
    public class BillboardController : Controller
    {
        private readonly IStatisticService _statisticService;
        private readonly IBookService _bookService;

        public BillboardController(IStatisticService statisticService, IBookService bookService)
        {
            _statisticService = statisticService;
            _bookService = bookService;
        }

        [Route("")]
        public IActionResult Index(string category, InteractionType sortBy = InteractionType.View, int order_date = (int)SortOrder.Descending)
        {
            var books = _bookService.GetAllBooks();
            books =  _statisticService.StatisticOfEachInteractionType(books, (InteractionType)sortBy);
            if (order_date == null || order_date == (int)SortOrder.Descending)
            {
                books = books.OrderByDescending(x => x.CreatedDate);
            }
            else
            {
                books = books.OrderBy(x => x.CreatedDate);
            }
            if (category != String.Empty)
            {
                books = books.Where(x => x.Category.Slug == category);
            }
            return View(books);
        }

    }
}
