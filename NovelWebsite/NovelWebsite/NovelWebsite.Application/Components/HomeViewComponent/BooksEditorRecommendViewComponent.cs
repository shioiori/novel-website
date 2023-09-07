using Microsoft.AspNetCore.Mvc;
using NovelWebsite.NovelWebsite.Core.Enums;
using NovelWebsite.NovelWebsite.Core.Interfaces;
using NovelWebsite.NovelWebsite.Core.Interfaces.Repositories;
using NovelWebsite.NovelWebsite.Core.Interfaces.Services;
using NovelWebsite.NovelWebsite.Domain.Services;

namespace NovelWebsite.NovelWebsite.Application.Components.HomeViewComponent
{
    public class BooksEditorRecommendViewComponent : ViewComponent
    {
        private readonly IBookService _bookService;
        private readonly IChapterService _chapterService;
        private readonly IBookUserRepository _bookUserRepository;
        public BooksEditorRecommendViewComponent(IBookService bookService, IChapterService chapterService)
        {
            _bookService = bookService;
            _chapterService = chapterService;
        }

        public IViewComponentResult Invoke(int number = 6)
        {
            var books = _bookService.GetBookByUserInteractive(InteractionType.EditorRecommend).Take(number);
            foreach (var item in books)
            {
                item.TotalChapters = _chapterService.GetChapters(item.BookId).Count();
            }
            return View(books);
        }
    }
}
