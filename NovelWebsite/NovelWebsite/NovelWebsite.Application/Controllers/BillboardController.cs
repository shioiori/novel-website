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
        public IActionResult Index(InteractionType sortBy, SortOrder? order, int categoryId = 0)
        {
            var books = _bookService.GetAllBooks();
            switch (sortBy)
            {
                case InteractionType.Follow:
                    books =  _statisticService.StatisticOfEachInteractionType(books, sortBy);
                    break;
                case InteractionType.Comment:
                    books = _statisticService.StatisticOfEachInteractionType(books, sortBy);
                    break;
                case InteractionType.Like:
                    books = _statisticService.StatisticOfEachInteractionType(books, sortBy);
                    break;
                case InteractionType.Recommend:
                    books = _statisticService.StatisticOfEachInteractionType(books, sortBy);
                    break;
                default:
                    books = _bookService.GetAllBooks();
                    break;
            }

            return View(books);
        }

    }
}
