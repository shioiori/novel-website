using Microsoft.EntityFrameworkCore;
using NovelWebsite.Application.Models.Request;
using Application.Utils;
using Application.Models.Dtos;
using NovelWebsite.Domain.Entities;
using Application.Services.Base;

namespace NovelWebsite.Application.Services
{
    public class AuthorService : GenericService<Author, AuthorDto>
    {
        public AuthorService() : base()
        {
        }

        public async Task<AuthorDto> GetAuthorByIdAsync(int id)
        {
            var author = await _repository.Get().FirstOrDefaultAsync(x => x.AuthorId == id);
            return await MapDtosAsync(author);
        }

        public async Task<AuthorDto> GetAuthorBySlugAsync(string slug)
        {
            var author = await _repository.Get().FirstOrDefaultAsync(x => x.Slug == slug);
            return await MapDtosAsync(author);
        }

        public async Task<AuthorDto> GetAuthorByNameAsync(string name)
        {
            var author = await _repository.Get().FirstOrDefaultAsync(x => x.AuthorName == name);
            if (author == null)
            {
                author = await _repository.Get(x => x.AuthorName.ToLower().Trim()
                                                                            .Equals(name.ToLower().Trim())).FirstOrDefaultAsync();
            }
            return await MapDtosAsync(author);
        }

        public async Task<IEnumerable<AuthorDto>> GetAllAuthor(PagedListRequest pagedListRequest = null)
        {
            var query = _repository.Get();
            var authors = PagedList<Author>.AsEnumerable(query, pagedListRequest);
            return await MapDtosAsync(authors);
        }
    }
}
