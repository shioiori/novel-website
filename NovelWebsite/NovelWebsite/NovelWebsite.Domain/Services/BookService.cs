using AutoMapper;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using NovelWebsite.Infrastructure.Entities;
using NovelWebsite.NovelWebsite.Core.Constants;
using NovelWebsite.NovelWebsite.Core.Enums;
using NovelWebsite.NovelWebsite.Core.Interfaces;
using NovelWebsite.NovelWebsite.Core.Models;
using System.Linq.Expressions;
using static System.Reflection.Metadata.BlobBuilder;

namespace NovelWebsite.Domain.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        Expression<Func<Book, bool>> expValidBooks = b => b.IsDeleted == false;
        Func<Book, bool> expFilterByAuthor(int authorId)
        {
            return b => b.AuthorId == authorId;
        }
        Func<Book, bool> expFilterByCategory(int categoryId)
        {
            return b => b.CategoryId == categoryId;
        }
        Func<Book, bool> expFilterByUploadStatus(UploadStatus status)
        {
            return b => b.Status == (int)status;
        }
        Func<Book, bool> expFilterByBookStatus(string bookStatus)
        {
            return b => b.BookStatus == bookStatus;
        }

        public BookService(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public IEnumerable<BookModel> GetBooks()
        {
            var books = _bookRepository.Filter(expValidBooks);
            return _mapper.Map<IEnumerable<Book>, IEnumerable<BookModel>>(books);
        }

        public IEnumerable<BookModel> GetBooksByAuthor(int authorId)
        {
            var books = _bookRepository.Filter(expValidBooks).Where(expFilterByAuthor(authorId));
            return _mapper.Map<IEnumerable<Book>, IEnumerable<BookModel>>(books); 
        }

        public IEnumerable<BookModel> GetBooksByCategory(int categoryId)
        {
            var books = _bookRepository.Filter(expValidBooks).Where(expFilterByCategory(categoryId));
            return _mapper.Map<IEnumerable<Book>, IEnumerable<BookModel>>(books);
        }

        public IEnumerable<BookModel> GetBooksByBookStatus(string status)
        {
            var books = _bookRepository.Filter(expValidBooks).Where(expFilterByBookStatus(status));
            return _mapper.Map<IEnumerable<Book>, IEnumerable<BookModel>>(books);
        }

        public IEnumerable<BookModel> GetBookByFilter(FilterModel filter)
        {
            throw new NotImplementedException();
            //var query = _dbContext.Books.Where(b => filterModel.CategoryId == 0 || b.CategoryId == filterModel.CategoryId)
            //.Include(b => b.Author)
            //                  .Include(b => b.BookStatus)
            //                  .Where(b => b.IsDeleted == false)
            //                  .ToList();
            //var final = query;
            //// lọc theo tình trạng
            //if (filterModel.BookStatus != null)
            //{
            //    var f1 = query.Where(b => b.BookStatusId == filterModel.BookStatus[0]).ToList();
            //    for (int i = 1; i < filterModel.BookStatus.Count(); i++)
            //    {
            //        var temp = query.Where(b => b.BookStatusId == filterModel.BookStatus[i]);
            //        foreach (var item in temp)
            //        {
            //            f1.Add(item);
            //        }
            //    }
            //    final = f1;
            //}

            //// lọc theo xếp hạng
            //if (!string.IsNullOrEmpty(filterModel.Rank))
            //{
            //    var f2 = final;
            //    switch (filterModel.Rank)
            //    {
            //        case "view":
            //            f2 = f2.OrderByDescending(b => b.Views).ToList();
            //            break;
            //        case "like":
            //            f2 = f2.OrderByDescending(b => b.Likes).ToList();
            //            break;
            //        case "recommend":
            //            f2 = f2.OrderByDescending(b => b.Recommends).ToList();
            //            break;
            //        case "follow":
            //            var mostFollow = _dbContext.BookUserFollows
            //                            .GroupBy(bu => bu.BookId)
            //                            .OrderByDescending(g => g.Count())
            //                            .Select(g => g.Key)
            //                            .ToList();
            //            f2 = f2.OrderBy(b =>
            //            {
            //                var index = mostFollow.IndexOf(b.BookId);
            //                return index == -1 ? mostFollow.Count : index;
            //            }).ToList();
            //            break;
            //        case "comment":
            //            var mostComment = _dbContext.Comments
            //                            .GroupBy(bu => bu.BookId)
            //                            .OrderByDescending(g => g.Count())
            //                            .Select(g => g.Key)
            //                            .ToList();
            //            f2 = f2.OrderBy(b =>
            //            {
            //                var index = mostComment.IndexOf(b.BookId);
            //                return index == -1 ? mostComment.Count : index;
            //            }).ToList();
            //            break;
            //        default:
            //            f2 = f2.OrderByDescending(b => b.CreatedDate).ToList();
            //            break;
            //    }
            //    final = f2;
            //}

            //// lọc theo số chương
            //if (filterModel.ChapterRange != null)
            //{
            //    var f3 = final;
            //    int minRange = filterModel.ChapterRange[0];
            //    f3 = f3.Where(b => b.NumberOfChapters <= filterModel.ChapterRange[0]).ToList();
            //    for (int i = 1; i < filterModel.ChapterRange.Count(); i++)
            //    {
            //        var temp = final.Where(b => b.NumberOfChapters <= filterModel.ChapterRange[i] && b.NumberOfChapters > minRange);
            //        minRange = filterModel.ChapterRange[i];
            //        foreach (var item in temp)
            //        {
            //            f3.Add(item);
            //        }
            //    }
            //    final = f3;
            //}
            //// sắp xếp

            //if (!string.IsNullOrEmpty(filterModel.OrderBy))
            //{
            //    var f4 = final;
            //    switch (filterModel.OrderBy)
            //    {
            //        case "new":
            //            f4 = f4.OrderByDescending(b => b.CreatedDate).ToList();
            //            break;
            //        case "old":
            //            f4 = f4.OrderBy(b => b.CreatedDate).ToList();
            //            break;
            //    }
            //    final = f4;
            //}

            //// lọc theo tag
            //// kiểm tra tag của những quyển đã có -> tag nào k có thì remove khỏi ds
            //if (filterModel.Tag != null)
            //{
            //    var f5 = new List<Book>(final);
            //    foreach (var item in final)
            //    {
            //        var temp = _dbContext.BookTags.Where(b => b.BookId == item.BookId).Select(b => b.TagId).ToList();
            //        if (temp.Count == 0)
            //        {
            //            f5.Remove(item);
            //            continue;
            //        }
            //        foreach (var tag in filterModel.Tag)
            //        {
            //            if (!temp.Contains(tag))
            //            {
            //                f5.Remove(item);
            //                break;
            //            }
            //        }
            //    }
            //    final = f5;
            //}

        }

        public IEnumerable<BookModel> GetAllBooks()
        {
            var books = _bookRepository.GetAll();
            return _mapper.Map<IEnumerable<Book>, IEnumerable<BookModel>>(books);
        }

        public BookModel GetBook(int bookId)
        {
            var book = _bookRepository.GetById(bookId);
            return _mapper.Map<Book, BookModel>(book);
        }

        public void CreateBook(BookModel book)
        {
            _bookRepository.Insert(_mapper.Map<BookModel, Book>(book));
        }
        public void UpdateBook(BookModel book)
        {
            _bookRepository.Update(_mapper.Map<BookModel, Book>(book));
        }
        public void DeleteBook(int bookId)
        {
            var book = _bookRepository.GetById(bookId);
            book.IsDeleted = true;
            _bookRepository.Update(book);
        }
        public void DeleteBookPermanent(int bookId)
        {
            _bookRepository.Delete(bookId);
        }

    }
}
