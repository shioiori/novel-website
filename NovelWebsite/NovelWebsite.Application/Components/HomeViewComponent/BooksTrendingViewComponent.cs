using Microsoft.AspNetCore.Mvc;
using NovelWebsite.NovelWebsite.Core.Enums;
using NovelWebsite.NovelWebsite.Core.Interfaces;
using NovelWebsite.NovelWebsite.Core.Interfaces.Services;
using NovelWebsite.NovelWebsite.Domain.Services;

namespace NovelWebsite.Application.Components.HomeViewComponent
{
    public class BooksTrendingViewComponent : ViewComponent
    {
        private readonly IStatisticService _statisticService;
        private readonly IBookService _bookService;
        private readonly IChapterService _chapterService;

        public BooksTrendingViewComponent(IStatisticService statisticService, IBookService bookService, IChapterService chapterService)
        {
            _statisticService = statisticService;
            _bookService = bookService;
            _chapterService = chapterService;
        }

        public IViewComponentResult Invoke(int number = 20, int rangeTime = 3)
        {
            var books = _bookService.GetBooksFromTime(DateTime.Now.AddMonths(rangeTime));
            var res = _statisticService.StatisticOfEachInteractionType(books, InteractionType.Comment).Take(number);
            foreach (var item in res)
            {
                item.TotalChapters = _chapterService.GetChapters(item.BookId).Count();
            }
            return View(res);
        }
    }
}
