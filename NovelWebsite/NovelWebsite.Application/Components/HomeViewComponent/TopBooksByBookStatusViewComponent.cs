using Microsoft.AspNetCore.Mvc;
using NovelWebsite.NovelWebsite.Core.Interfaces;
using NovelWebsite.NovelWebsite.Core.Interfaces.Services;
using NovelWebsite.NovelWebsite.Domain.Services;

namespace NovelWebsite.Application.Components.HomeViewComponent
{
    public class TopBooksByBookStatusViewComponent : ViewComponent
    {
        private readonly IBookService _bookService;
        private readonly IChapterService _chapterService;

        public TopBooksByBookStatusViewComponent(IBookService bookService, IChapterService chapterService)
        {
            _bookService = bookService;
            _chapterService = chapterService;
        }

        public IViewComponentResult Invoke(string status, int number = 10)
        {
            var books = _bookService.GetBooksByBookStatus(status).Take(number);
            foreach (var item in books)
            {
                item.TotalChapters = _chapterService.GetChapters(item.BookId).Count();
            }
            return View(books);
        }
    }
}
