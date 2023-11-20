using NovelWebsite.NovelWebsite.Infrastructure.Entities;
using NovelWebsite.NovelWebsite.Core.Enums;
using NovelWebsite.NovelWebsite.Core.Interfaces.Repositories;
using NovelWebsite.NovelWebsite.Core.Models;

namespace NovelWebsite.NovelWebsite.Domain.Services
{
    public class BookInteractionService : InteractionService
    {
        private readonly IBookUserRepository _bookUserRepository;

        public BookInteractionService(IBookUserRepository bookUserRepository)
        {
            _bookUserRepository = bookUserRepository;
        }

        public override bool IsInteractionEnabled(string tId, string uId, InteractionType type)
        {
            var book = _bookUserRepository.GetByExpression(x => x.BookId == tId && x.UserId == uId && x.InteractionId == (int)type);
            if (book == null)
            {
                return false;
            }
            return true;
        }

        public override bool SetStatusOfInteraction(string tId, string uId, InteractionType type)
        {
            var book = _bookUserRepository.GetByExpression(x => x.BookId == tId && x.UserId == uId && x.InteractionId == (int)type);
            if (book == null)
            {
                book = new BookUsers()
                {
                    BookId = tId,
                    UserId = uId,
                    InteractionId = (int)type,
                };
                _bookUserRepository.Insert(book);
                _bookUserRepository.Save();
                return true;
            }
            _bookUserRepository.Delete(book);
            _bookUserRepository.Save();
            return false;

        }
    }
}
