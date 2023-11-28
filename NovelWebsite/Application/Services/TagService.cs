using AutoMapper;
using NovelWebsite.NovelWebsite.Infrastructure.Entities;
using NovelWebsite.Application.Interfaces.Repositories;
using NovelWebsite.Application.Interfaces.Services;
using NovelWebsite.Application.Models.Request;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Application.Utils;
using Application.Models.Dtos;

namespace NovelWebsite.Application.Services
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

        public IEnumerable<TagDto> GetAll(PagedListRequest pagedListRequest = null)
        {
            var query = _tagRepository.GetAll();
            var tags = PagedList<Tag>.AsEnumerable(query, pagedListRequest);
            return _mapper.Map<IEnumerable<Tag>, IEnumerable<TagDto>>(tags);
        }

        public async Task AddAsync(TagDto tag)
        {
            await _tagRepository.InsertAsync(_mapper.Map<TagDto, Tag>(tag));
            _tagRepository.SaveAsync();
        }

        public async Task UpdateAsync(TagDto tag)
        {
            await _tagRepository.UpdateAsync(_mapper.Map<TagDto, Tag>(tag));
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

        public async Task<TagDto> GetByIdAsync(int tagId){
            var tag = await _tagRepository.GetByIdAsync(tagId);
            return _mapper.Map<Tag, TagDto>(tag);
        }

        public async Task<TagDto> GetTagByNameAsync(string name)
        {
            var tag = await _tagRepository.GetByExpressionAsync(x => x.TagName == name);
            return _mapper.Map<Tag, TagDto>(tag);
        }

        public async Task<TagDto> GetTagBySlugAsync(string slug)
        {
            var tag = await _tagRepository.GetByExpressionAsync(x => x.Slug == slug);
            return _mapper.Map<Tag, TagDto>(tag);
        }

        public async Task<IEnumerable<TagDto>> GetTagsOfBookAsync(string bookId, PagedListRequest pagedListRequest = null)
        {
            var bookTags = _bookTagRepository.Get(x => x.BookId == bookId);
            var tags = new List<Tag>();
            foreach (var bookTag in bookTags)
            {
                tags.Add(await _tagRepository.GetByIdAsync(bookTag.TagId));
            }
            return _mapper.Map<List<Tag>, List<TagDto>>(tags);
        }

        public async Task AddTagsOfBookAsync(string bookId, IEnumerable<TagDto> tags)
        {
            var prevTags = _bookTagRepository.Get(x => x.BookId == bookId);
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