using NovelWebsite.Infrastructure.Entities;
using NovelWebsite.NovelWebsite.Core.Enums;
using NovelWebsite.NovelWebsite.Core.Interfaces.Repositories;
using NovelWebsite.NovelWebsite.Core.Models;

namespace NovelWebsite.NovelWebsite.Domain.Services
{
    public class BookInteractionService : InterationService
    {
        private readonly IBookUserRepository _bookUserRepository;

        public BookInteractionService(IBookUserRepository bookUserRepository)
        {
            _bookUserRepository = bookUserRepository;
        }

        public override bool IsInteractionEnabled(int tId, int uId, InteractionType type)
        {
            var book = _bookUserRepository.Filter(x => x.BookId == tId && x.UserId == uId && x.InteractType == (int)type);
            if (book == null)
            {
                return false;
            }
            return true;
        }

        public override bool SetStatusOfInteraction(int tId, int uId, InteractionType type)
        {
            var book = _bookUserRepository.GetByExpression(x => x.BookId == tId && x.UserId == uId && x.InteractType == (int)type);
            if (book == null)
            {
                book = new Book_User()
                {
                    BookId = tId,
                    UserId = uId,
                    InteractType = (int)type,
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
