using AutoMapper;
using NovelWebsite.NovelWebsite.Infrastructure.Entities;
using NovelWebsite.NovelWebsite.Core.Interfaces.Repositories;
using NovelWebsite.NovelWebsite.Core.Interfaces.Services;
using NovelWebsite.NovelWebsite.Core.Models;

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

        public AuthorModel GetAuthorsById(int id)
        {
            var author = _authorRepository.GetById(id);
            return _mapper.Map<Author, AuthorModel>(author); 
        }

        public AuthorModel GetAuthorBySlug(string slug)
        {
            var author = _authorRepository.GetByExpression(x => x.Slug == slug);
            return _mapper.Map<Author, AuthorModel>(author);
        }

        public AuthorModel CreateAuthor(AuthorModel author)
        {
            var res = _authorRepository.Insert(_mapper.Map<AuthorModel, Author>(author));
            _authorRepository.Save();
            author.AuthorId = res.AuthorId;
            author.Slug = res.Slug;
            return author;
        }

        public void UpdateAuthor(AuthorModel author)
        {
            _authorRepository.Update(_mapper.Map<AuthorModel, Author>(author));
            _authorRepository.Save();
        }

        public void DeleteAuthor(int authorId)
        {
            _authorRepository.Delete(authorId);
            _authorRepository.Save();
        }

        public AuthorModel GetAuthorByName(string name)
        {
            var author = _authorRepository.GetByExpression(x => x.AuthorName == name);
            if (author == null)
            {
                author = _authorRepository.Filter(x => x.AuthorName.ToLower().Trim()
                                                                            .Equals(name.ToLower().Trim())).FirstOrDefault();
            }
            return _mapper.Map<Author, AuthorModel>(author);
        }

        public IEnumerable<AuthorModel> GetAllAuthor()
        {
            var authors = _authorRepository.GetAll();
            return _mapper.Map<IEnumerable<Author>, IEnumerable<AuthorModel>>(authors);
        }
    }
}
