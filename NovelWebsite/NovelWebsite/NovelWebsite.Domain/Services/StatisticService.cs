using AutoMapper;
using Microsoft.Data.SqlClient;
using NovelWebsite.Infrastructure.Entities;
using NovelWebsite.NovelWebsite.Core.Enums;
using NovelWebsite.NovelWebsite.Core.Interfaces;
using NovelWebsite.NovelWebsite.Core.Interfaces.Repositories;
using NovelWebsite.NovelWebsite.Core.Interfaces.Services;
using NovelWebsite.NovelWebsite.Core.Models;
using System.Linq.Expressions;
using static System.Reflection.Metadata.BlobBuilder;

namespace NovelWebsite.NovelWebsite.Domain.Services
{
    public class StatisticService : IStatisticService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IBookUserRepository _bookUserRepository;
        private readonly IMapper _mapper;
        Expression<Func<Book, bool>> expFilterByCategory(int categoryId)
        {
            return b => categoryId == 0 || b.CategoryId == categoryId;
        }
        Expression<Func<BookUsers, bool>> expFilterInteractionType(InteractionType type)
        {
            return x => x.InteractType == (int)type;
        }
        public StatisticService(IBookRepository bookRepository, IBookUserRepository bookUserRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _bookUserRepository = bookUserRepository;
            _mapper = mapper;
        }
        public IEnumerable<BookModel> StatisticOfEachInteractionType(IEnumerable<BookModel> books, InteractionType type)
        {
            if (type == InteractionType.View)
            {
                var res = books.OrderByDescending(x => x.Views);
                return res;
            }
            var list = _bookUserRepository.Filter(expFilterInteractionType(type))
                             .GroupBy(b => b.BookId)
                             .OrderByDescending(g => g.Count())
                             .Select(g => new
                             {
                                 BookId = g.Key,
                                 InteractionCount = g.Count(),
                                 InteractionType = type,
                             }).ToList();
            books = books.OrderBy(b =>
            {
                var index = list.FindIndex(x => x.BookId == b.BookId);
                return index == -1 ? list.Count : index;
            });
            return books;
        }
    }
}
