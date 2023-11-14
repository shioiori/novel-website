using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NovelWebsite.Domain.Services;
using NovelWebsite.NovelWebsite.Core.Enums;
using NovelWebsite.NovelWebsite.Core.Interfaces;
using NovelWebsite.NovelWebsite.Core.Interfaces.Services;
using NovelWebsite.NovelWebsite.Core.Models;
using System.Security.Cryptography;

namespace NovelWebsite.NovelWebsite.Api.Controllers
{
    [Route("/billboard")]
    [ApiController]
    public class BillboardController : ControllerBase
    {
        private readonly IStatisticService _statisticService;
        private readonly IBookService _bookService;

        public BillboardController(IStatisticService statisticService,
                                   IBookService bookService)
        {
            _statisticService = statisticService;
            _bookService = bookService;
        }

        [HttpGet]
        [Route("get-by-filter")]
        public IEnumerable<BookModel> GetByFilter(string? category, string? sortBy, string? orderDate)
        {
            SortOrder ordDate = SortOrder.Descending;
            if (!string.IsNullOrEmpty(orderDate)){
                if (int.TryParse(orderDate, out int ord))
                {
                    ordDate = (SortOrder)ord;
                }
                else
                {
                    ordDate = (SortOrder)Enum.Parse(typeof(SortOrder), orderDate, true);
                }
            }
            InteractionType type = InteractionType.View;
            if (!string.IsNullOrEmpty(sortBy))
            {
                if (int.TryParse(sortBy, out int sort))
                {
                    type = (InteractionType)sort;
                }
                else
                {
                    type = (InteractionType)Enum.Parse(typeof(InteractionType), orderDate, true);
                }
            }
            var books = _bookService.GetAll();
            books = _statisticService.StatisticOfEachInteractionType(books, type);
            switch (ordDate)
            {
                case SortOrder.Descending:
                    books = books.OrderByDescending(x => x.CreatedDate);
                    break;
                case SortOrder.Ascending:
                    books = books.OrderBy(x => x.CreatedDate);
                    break;
                default:
                    books = books.OrderByDescending(x => x.CreatedDate);
                    break;
            }
            if (category != String.Empty)
            {
                books = books.Where(x => x.Category.Slug == category);
            }
            return books;
        }
    }
}
