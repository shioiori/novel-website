using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NovelWebsite.Domain.Services;
using NovelWebsite.NovelWebsite.Core.Enums;
using NovelWebsite.NovelWebsite.Core.Interfaces;
using NovelWebsite.NovelWebsite.Core.Interfaces.Services;
using NovelWebsite.NovelWebsite.Core.Models;
using NovelWebsite.NovelWebsite.Core.Models.Request;
using NovelWebsite.NovelWebsite.Core.Models.Response;
using NovelWebsite.NovelWebsite.Domain.Services;
using NovelWebsite.NovelWebsite.Infrastructure.Entities;
using System.Security.Cryptography;

namespace NovelWebsite.NovelWebsite.Api.Controllers
{
    [Route("/billboard")]
    [ApiController]
    public class BillboardController : ControllerBase
    {
        private readonly BookService _bookService;
        public BillboardController(BookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        [Route("get-by-filter")]
        public PagedList<BookModel> GetByFilter(int category, string interaction, string sortOrder, [FromQuery] PagedListRequest request)
        {
            SortOrder ordDate = SortOrder.Descending;
            if (!string.IsNullOrEmpty(sortOrder)){
                if (int.TryParse(sortOrder, out int ord))
                {
                    ordDate = (SortOrder)ord;
                }
                else
                {
                    ordDate = (SortOrder)Enum.Parse(typeof(SortOrder), sortOrder, true);
                }
            }
            InteractionType type = InteractionType.View;
            if (!string.IsNullOrEmpty(interaction))
            {
                if (int.TryParse(interaction, out int sort))
                {
                    type = (InteractionType)sort;
                }
                else
                {
                    type = (InteractionType)Enum.Parse(typeof(InteractionType), sortOrder, true);
                }
            }
            IEnumerable<BookModel> books = null;
            if (category != 0)
            {
                books = _bookService.GetByCategory(category);
            }
            else
            {
                books = _bookService.GetAll();
            }
            books = _bookService.GetTopEachInteractionType(books, type);
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
            return PagedList<BookModel>.ToPagedList(books);
        }
    }
}
