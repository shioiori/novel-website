using Microsoft.AspNetCore.Mvc;
using NovelWebsite.NovelWebsite.Core.Enums;
using NovelWebsite.NovelWebsite.Core.Interfaces;
using NovelWebsite.NovelWebsite.Core.Interfaces.Services;
using NovelWebsite.NovelWebsite.Domain.Services;

namespace NovelWebsite.Application.Components.HomeViewComponent
{
    public class TopBooksByInteractionViewComponent : ViewComponent
    {
        private readonly IStatisticService _statisticService;
        private readonly IBookService _bookService;

        public TopBooksByInteractionViewComponent(IStatisticService statisticService, IBookService bookService)
        {
            _statisticService = statisticService;
            _bookService = bookService;
        }

        public IViewComponentResult Invoke(InteractionType type, string title, int number = 10)
        {
            var books = _bookService.GetBooks();
            var res = _statisticService.StatisticOfEachInteractionType(books, type).Take(number);
            ViewBag.Title = title;
            return View(res);
        }
    }
}
