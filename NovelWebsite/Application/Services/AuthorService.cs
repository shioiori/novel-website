using Microsoft.EntityFrameworkCore;
using NovelWebsite.Application.Models.Request;
using Application.Utils;
using Application.Models.Dtos;
using NovelWebsite.Domain.Entities;
using Application.Services.Base;
using NovelWebsite.Domain.Interfaces;
using AutoMapper;
using Application.Interfaces;

namespace NovelWebsite.Application.Services
{
    public class AuthorService : GenericService<Author, AuthorDto>, IAuthorService
    {
        public AuthorService(IAuthorRepository authorRepository, IMapper mapper) : base(authorRepository, mapper)
        {
        }

        public async Task<AuthorDto> GetByIdAsync(int id)
        {
            var author = _repository.Get().FirstOrDefault(x => x.AuthorId == id);
            return await MapDtoAsync(author);
        }

        public async Task<AuthorDto> GetBySlugAsync(string slug)
        {
            var author = _repository.Get().FirstOrDefault(x => x.Slug == slug);
            return await MapDtoAsync(author);
        }

        public async Task<AuthorDto> GetByNameAsync(string name)
        {
            var author = _repository.Get().FirstOrDefault(x => x.AuthorName == name);
            if (author == null)
            {
                author = await _repository.Get(x => x.AuthorName.ToLower().Trim()
                                                                            .Equals(name.ToLower().Trim())).FirstOrDefaultAsync();
            }
            return await MapDtoAsync(author);
        }


        public async Task<IEnumerable<AuthorDto>> GetAllAsync(PagedListRequest pagedListRequest = null)
        {
            var query = _repository.Get();
            var authors = PagedList<Author>.AsEnumerable(query, pagedListRequest);
            return await MapDtosAsync(authors);
        }
    }
}
