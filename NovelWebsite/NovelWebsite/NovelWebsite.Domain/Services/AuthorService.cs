using AutoMapper;
using NovelWebsite.Infrastructure.Entities;
using NovelWebsite.NovelWebsite.Core.Interfaces.Repositories;
using NovelWebsite.NovelWebsite.Core.Interfaces.Services;
using NovelWebsite.NovelWebsite.Core.Models;

namespace NovelWebsite.NovelWebsite.Domain.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public AuthorService(IAuthorRepository authorRepository, IMapper mapper) 
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public AuthorModel GetAuthorsById(int id)
        {
            var author = _authorRepository.GetById(id);
            return _mapper.Map<AuthorEntity, AuthorModel>(author); 
        }
    }
}
