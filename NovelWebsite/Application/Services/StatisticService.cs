using AutoMapper;
using Microsoft.Data.SqlClient;
using NovelWebsite.NovelWebsite.Infrastructure.Entities;
using NovelWebsite.Application.Enums;
using NovelWebsite.Application.Interfaces;
using NovelWebsite.Application.Interfaces.Repositories;
using NovelWebsite.Application.Interfaces.Services;
using System.Linq.Expressions;
using static System.Reflection.Metadata.BlobBuilder;
using Application.Models.Dtos;

namespace NovelWebsite.Application.Services
{
    public class StatisticService
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
            return x => x.InteractionId == (int)type;
        }
        public StatisticService(IBookRepository bookRepository, IBookUserRepository bookUserRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _bookUserRepository = bookUserRepository;
            _mapper = mapper;
        }
        public IEnumerable<BookDto> StatisticOfEachInteractionType(IEnumerable<BookDto> books, InteractionType type)
        {
            if (type == InteractionType.View)
            {
                var res = books.OrderByDescending(x => x.Views);
                return res;
            }
            var list = _bookUserRepository.Get(expFilterInteractionType(type))
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
