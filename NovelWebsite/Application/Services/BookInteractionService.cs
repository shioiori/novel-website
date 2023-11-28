

using Application.Interfaces;
using Application.Services.Base;
using Microsoft.EntityFrameworkCore;
using NovelWebsite.Domain.Entities;
using NovelWebsite.Domain.Enums;

namespace NovelWebsite.Application.Services
{
    public class BookInteractionService : GenericService<BookUsers, BookUsersDto>, IInteractionService
    {
        public BookInteractionService() : base() { }

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
            var book = await _repository.Get(x => x.BookId == tId && x.UserId == uId && x.InteractionId == (int)type).FirstOrDefaultAsync();
            if (book == null)
            {
                book = new BookUsers()
                {
                    BookId = tId,
                    UserId = uId,
                    InteractionId = (int)type,
                };
                await _repository.InsertAsync(book);
                _repository.SaveAsync();
                return true;
            }
            _repository.Delete(book);
            _repository.SaveAsync();
            return false;

        }
    }
}
