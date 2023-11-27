using AutoMapper;
using NovelWebsite.NovelWebsite.Infrastructure.Entities;
using NovelWebsite.NovelWebsite.Core.Interfaces.Repositories;
using NovelWebsite.NovelWebsite.Core.Interfaces.Services;
using NovelWebsite.NovelWebsite.Core.Models;
using Microsoft.EntityFrameworkCore;
using NovelWebsite.NovelWebsite.Core.Models.Request;
using NovelWebsite.NovelWebsite.Core.Models.Response;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace NovelWebsite.NovelWebsite.Domain.Services
{
    public class AuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public AuthorService(IAuthorRepository authorRepository, IMapper mapper) 
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public async Task<AuthorModel> GetAuthorsByIdAsync(int id)
        {
            var author = await _authorRepository.GetByIdAsync(id);
            return _mapper.Map<Author, AuthorModel>(author); 
        }

        public async Task<AuthorModel> GetAuthorBySlugAsync(string slug)
        {
            var author = await _authorRepository.GetByExpressionAsync(x => x.Slug == slug);
            return _mapper.Map<Author, AuthorModel>(author);
        }

        public async Task CreateAuthorAsync(AuthorModel author)
        {
            var res = await _authorRepository.InsertAsync(_mapper.Map<AuthorModel, Author>(author));
            _authorRepository.SaveAsync();
        }

        public async Task UpdateAuthorAsync(AuthorModel author)
        {
            _authorRepository.UpdateAsync(_mapper.Map<AuthorModel, Author>(author));
            _authorRepository.SaveAsync();
        }

        public async Task DeleteAuthorAsync(int authorId)
        {
            _authorRepository.DeleteAsync(authorId);
            _authorRepository.SaveAsync();
            return;
        }


        public async Task<AuthorModel> GetAuthorByNameAsync(string name)
        {
            var author = await _authorRepository.GetByExpressionAsync(x => x.AuthorName == name);
            if (author == null)
            {
                author = await _authorRepository.Filter(x => x.AuthorName.ToLower().Trim()
                                                                            .Equals(name.ToLower().Trim())).FirstOrDefaultAsync();
            }
            return _mapper.Map<Author, AuthorModel>(author);
        }

        public IEnumerable<AuthorModel> GetAllAuthor(PagedListRequest pagedListRequest = null)
        {
            var query = _authorRepository.GetAll();
            var authors = PagedList<Author>.AsEnumerable(query, pagedListRequest);
            return _mapper.Map<IEnumerable<Author>, IEnumerable<AuthorModel>>(authors);
        }
    }
}
