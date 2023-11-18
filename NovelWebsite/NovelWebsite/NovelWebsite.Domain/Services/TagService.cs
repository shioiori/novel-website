using AutoMapper;
using NovelWebsite.NovelWebsite.Infrastructure.Entities;
using NovelWebsite.NovelWebsite.Core.Interfaces.Repositories;
using NovelWebsite.NovelWebsite.Core.Interfaces.Services;
using NovelWebsite.NovelWebsite.Core.Models;

namespace NovelWebsite.NovelWebsite.Domain.Services
{
    public class TagService
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

        public IEnumerable<TagModel> GetAll()
        {
            var categories = _tagRepository.GetAll();
            return _mapper.Map<IEnumerable<Tag>, IEnumerable<TagModel>>(categories);
        }

        public TagModel Add(TagModel tag)
        {
            var res = _tagRepository.Insert(_mapper.Map<TagModel, Tag>(tag));
            _tagRepository.Save();
            return _mapper.Map<Tag, TagModel>(res);
        }

        public TagModel Update(TagModel tag)
        {
            var res = _tagRepository.Update(_mapper.Map<TagModel, Tag>(tag));
            _tagRepository.Save();
            return _mapper.Map<Tag, TagModel>(res);
        }

        public void Delete(int id)
        {
            _tagRepository.Delete(id);
            _tagRepository.Save();
        }

        public TagModel GetById(int tagId){
            var tag = _tagRepository.GetById(tagId);
            return _mapper.Map<Tag, TagModel>(tag);
        }

        public TagModel GetTagByName(string name)
        {
            var tag = _tagRepository.GetByExpression(x => x.TagName == name);
            return _mapper.Map<Tag, TagModel>(tag);
        }

        public TagModel GetTagBySlug(string slug)
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

        public void AddTagsOfBook(string bookId, IEnumerable<TagModel> tags)
        {
            var prevTags = _bookTagRepository.Filter(x => x.BookId == bookId);
            foreach (var tag in prevTags)
            {
                _bookTagRepository.Delete(prevTags);
            }
            foreach (var tag in tags)
            {
                _bookTagRepository.Insert(new BookTags()
                {
                    BookId = bookId,
                    TagId = tag.TagId,
                });
            }
            _bookTagRepository.Save();
        }
    }
}