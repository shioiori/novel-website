using NovelWebsite.NovelWebsite.Core.Models;

namespace NovelWebsite.NovelWebsite.Core.Interfaces.Services
{
    public interface IAuthorService
    {
        AuthorModel GetAuthorsById(int id);
        AuthorModel GetAuthorBySlug(string slug);
    }
}
