

using Application.Interfaces;
using Application.Models.Dtos;
using Application.Services.Base;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NovelWebsite.Domain.Entities;
using NovelWebsite.Domain.Enums;
using NovelWebsite.Domain.Interfaces;
using System;

namespace NovelWebsite.Application.Services
{
    public class BookInteractionService : GenericService<BookUsers, BookUserDto>, IBookInteractionService
    {
        private readonly IBookRepository _bookRepository;

        public BookInteractionService(IBookUserRepository bookUserRepository,
            IMapper mapper,
            IBookRepository bookRepository) : base(bookUserRepository, mapper)
        {
            _bookRepository = bookRepository;
        }

        public async Task<bool> IsInteractionEnabledAsync(string tId, string uId, InteractionType type)
        {
            var book = _repository.Get(x => x.BookId == tId && x.UserId == uId && x.InteractionId == (int)type).FirstOrDefaultAsync();
            if (book == null)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> SetStatusOfInteractionAsync(string tId, string uId, InteractionType type)
        {
            var bookUser = await _repository.Get(x => x.BookId == tId && x.UserId == uId && x.InteractionId == (int)type).FirstOrDefaultAsync();
            var book = _bookRepository.Get(x => x.BookId == bookUser.BookId).FirstOrDefault();
            if (bookUser == null)
            {
                bookUser = new BookUsers()
                {
                    BookId = tId,
                    UserId = uId,
                    InteractionId = (int)type,
                };
                _repository.InsertAsync(bookUser);
                switch (type)
                {
                    case InteractionType.Like:
                        book.Likes = book.Likes + 1;
                        break;
                    case InteractionType.Follow:
                        book.Follows = book.Follows + 1;
                        break;
                    case InteractionType.Recommend:
                        book.Recommend = book.Recommend + 1;
                        break;
                    default:
                        break;
                }
                _bookRepository.UpdateAsync(book);
                _repository.SaveAsync();
                return true;
            }
            _repository.Delete(bookUser);
            switch (type)
            {
                case InteractionType.Like:
                    book.Likes = book.Likes - 1;
                    break;
                case InteractionType.Follow:
                    book.Follows = book.Follows - 1;
                    break;
                case InteractionType.Recommend:
                    book.Recommend = book.Recommend - 1;
                    break;
                default:
                    break;
            }
            _repository.SaveAsync();
            return false;
        }

        public async Task MarkAsync(string bId, string uId, string cId)
        {
            var mark = await _repository.Get(x => x.BookId == bId && x.UserId == uId
                                    && x.InteractionId == (int)InteractionType.Mark).FirstOrDefaultAsync();
            if (mark == null)
            {
                await _repository.InsertAsync(new BookUsers()
                {
                    BookId = bId,
                    UserId = uId,
                    InteractionId = (int)InteractionType.Mark,
                    ChapterId = cId,
                });
            }
            else
            {
                mark.ChapterId = cId;
                await _repository.UpdateAsync(mark);
            }
            _repository.SaveAsync();
        }
    }
}
