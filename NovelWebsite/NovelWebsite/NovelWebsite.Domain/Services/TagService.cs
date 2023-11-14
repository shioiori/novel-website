using AutoMapper;
using NovelWebsite.NovelWebsite.Infrastructure.Entities;
using NovelWebsite.NovelWebsite.Core.Interfaces.Repositories;
using NovelWebsite.NovelWebsite.Core.Interfaces.Services;
using NovelWebsite.NovelWebsite.Core.Models;

namespace NovelWebsite.NovelWebsite.Domain.Services
{
    public class TagService : ITagService
    {
        private readonly ITagRepository _tagRepository;
        private readonly IBookTagRepository _bookTagRepository;
        private readonly IMapper _mapper;

        public TagService(ITagRepository tagRepository, 
            IBookTagRepository bookTagRepository,
            IMapper mapper)
        {
            _tagRepository = tagRepository;
            _bookTagRepository = bookTagRepository;
            _mapper = mapper;
        }

        public IEnumerable<TagModel> GetAllTags()
        {
            var categories = _tagRepository.GetAll();
            return _mapper.Map<IEnumerable<Tag>, IEnumerable<TagModel>>(categories);
        }

        public void AddTag(TagModel tag)
        {
            _tagRepository.Insert(_mapper.Map<TagModel, Tag>(tag));
            _tagRepository.Save();
        }

        public void UpdateTag(TagModel tag)
        {
            _tagRepository.Update(_mapper.Map<TagModel, Tag>(tag));
            _tagRepository.Save();
        }

        public void RemoveTag(int tagId)
        {
            _tagRepository.Delete(tagId);
            _tagRepository.Save();
        }

        public TagModel GetTag(int tagId){
            var tag = _tagRepository.GetById(tagId);
            return _mapper.Map<Tag, TagModel>(tag);
        }

        public TagModel GetTag(string slug)
        {
            var tag = _tagRepository.GetByExpression(x => x.Slug == slug);
            return _mapper.Map<Tag, TagModel>(tag);
        }

        public IEnumerable<TagModel> GetTagsOfBook(string bookId)
        {
            var bookTags = _bookTagRepository.Filter(x => x.BookId == bookId);
            var tags = new List<Tag>();
            foreach (var bookTag in bookTags)
            {
                tags.Add(_tagRepository.GetById(bookTag.TagId));
            }
            return _mapper.Map<List<Tag>, List<TagModel>>(tags);
        }
    }
}