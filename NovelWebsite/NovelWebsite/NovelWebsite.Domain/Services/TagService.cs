using AutoMapper;
using NovelWebsite.NovelWebsite.Infrastructure.Entities;
using NovelWebsite.NovelWebsite.Core.Interfaces.Repositories;
using NovelWebsite.NovelWebsite.Core.Interfaces.Services;
using NovelWebsite.NovelWebsite.Core.Models;
using NovelWebsite.NovelWebsite.Core.Models.Request;
using NovelWebsite.NovelWebsite.Core.Models.Response;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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

        public IEnumerable<TagModel> GetAll(PagedListRequest pagedListRequest = null)
        {
            var query = _tagRepository.GetAll();
            var tags = PagedList<Tag>.AsEnumerable(query, pagedListRequest);
            return _mapper.Map<IEnumerable<Tag>, IEnumerable<TagModel>>(tags);
        }

        public async Task AddAsync(TagModel tag)
        {
            await _tagRepository.InsertAsync(_mapper.Map<TagModel, Tag>(tag));
            _tagRepository.SaveAsync();
        }

        public async Task UpdateAsync(TagModel tag)
        {
            await _tagRepository.UpdateAsync(_mapper.Map<TagModel, Tag>(tag));
            _tagRepository.SaveAsync();
        }

        public async Task DeleteAsync(string name)
        {
            Tag tag;
            if (int.TryParse(name, out int id))
            {
                tag = await _tagRepository.GetByIdAsync(id);
            }
            tag = await _tagRepository.GetByExpressionAsync(x => x.TagName == name);
            _tagRepository.Delete(tag);
            _tagRepository.SaveAsync();
        }

        public async Task<TagModel> GetByIdAsync(int tagId){
            var tag = await _tagRepository.GetByIdAsync(tagId);
            return _mapper.Map<Tag, TagModel>(tag);
        }

        public async Task<TagModel> GetTagByNameAsync(string name)
        {
            var tag = await _tagRepository.GetByExpressionAsync(x => x.TagName == name);
            return _mapper.Map<Tag, TagModel>(tag);
        }

        public async Task<TagModel> GetTagBySlugAsync(string slug)
        {
            var tag = await _tagRepository.GetByExpressionAsync(x => x.Slug == slug);
            return _mapper.Map<Tag, TagModel>(tag);
        }

        public async Task<IEnumerable<TagModel>> GetTagsOfBookAsync(string bookId, PagedListRequest pagedListRequest = null)
        {
            var bookTags = _bookTagRepository.Filter(x => x.BookId == bookId);
            var tags = new List<Tag>();
            foreach (var bookTag in bookTags)
            {
                tags.Add(await _tagRepository.GetByIdAsync(bookTag.TagId));
            }
            return _mapper.Map<List<Tag>, List<TagModel>>(tags);
        }

        public async Task AddTagsOfBookAsync(string bookId, IEnumerable<TagModel> tags)
        {
            var prevTags = _bookTagRepository.Filter(x => x.BookId == bookId);
            foreach (var tag in prevTags)
            {
                _bookTagRepository.Delete(tag);
            }
            foreach (var tag in tags)
            {
                await _bookTagRepository.InsertAsync(new BookTags()
                {
                    BookId = bookId,
                    TagId = tag.TagId,
                });
            }
            _bookTagRepository.SaveAsync();
        }
    }
}