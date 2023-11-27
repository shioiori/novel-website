using NovelWebsite.NovelWebsite.Infrastructure.Entities;
using NovelWebsite.NovelWebsite.Core.Enums;
using NovelWebsite.NovelWebsite.Core.Interfaces.Repositories;
using NovelWebsite.NovelWebsite.Core.Models;
using NovelWebsite.NovelWebsite.Core.Interfaces.Services;

namespace NovelWebsite.NovelWebsite.Domain.Services
{
    public class BookInteractionService : IInteractionService
    {
        private readonly IBookUserRepository _bookUserRepository;

        public BookInteractionService(IBookUserRepository bookUserRepository)
        {
            _bookUserRepository = bookUserRepository;
        }

        public async Task<bool> IsInteractionEnabledAsync(string tId, string uId, InteractionType type)
        {
            var book = await _bookUserRepository.GetByExpressionAsync(x => x.BookId == tId && x.UserId == uId && x.InteractionId == (int)type);
            if (book == null)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> SetStatusOfInteractionAsync(string tId, string uId, InteractionType type)
        {
            var book = await _bookUserRepository.GetByExpressionAsync(x => x.BookId == tId && x.UserId == uId && x.InteractionId == (int)type);
            if (book == null)
            {
                book = new BookUsers()
                {
                    BookId = tId,
                    UserId = uId,
                    InteractionId = (int)type,
                };
                await _bookUserRepository.InsertAsync(book);
                _bookUserRepository.SaveAsync();
                return true;
            }
            _bookUserRepository.Delete(book);
            _bookUserRepository.SaveAsync();
            return false;

        }
    }
}
