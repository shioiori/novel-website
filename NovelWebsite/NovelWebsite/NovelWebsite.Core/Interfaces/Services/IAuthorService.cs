using NovelWebsite.NovelWebsite.Core.Models;

namespace NovelWebsite.NovelWebsite.Core.Interfaces.Services
{
    public interface IAuthorService
    {
        AuthorModel GetAuthorsById(int id);
        AuthorModel GetAuthorBySlug(string slug);
        AuthorModel GetAuthorByName(string name);
        IEnumerable<AuthorModel> GetAllAuthor();
        void CreateAuthor(AuthorModel author);
        void UpdateAuthor(AuthorModel author);
        void DeleteAuthor(int authorId);
    }
}
