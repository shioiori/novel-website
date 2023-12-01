using NovelWebsite.Application.Models.Requests;
using NovelWebsite.Application.Utils;
using NovelWebsite.Application.Models.Dtos;
using NovelWebsite.Domain.Entities;
using Application.Services.Base;
using NovelWebsite.Domain.Interfaces;
using AutoMapper;
using NovelWebsite.Application.Interfaces;

namespace NovelWebsite.Application.Services
{
    public class TagService : GenericService<Tag, TagDto>, ITagService
    {
        private readonly IBookTagRepository _bookTagRepository;
        public TagService(IBookTagRepository bookTagRepository,
            ITagRepository tagRepository,
            IMapper mapper) : base(tagRepository, mapper)
        {
            _bookTagRepository = bookTagRepository;
        }
        public async Task<IEnumerable<TagDto>> GetAllAsync(PagedListRequest pagedListRequest)
        {
            var query = _repository.Get();
            var tags = PagedList<Tag>.AsEnumerable(query, pagedListRequest);
            return await MapDtosAsync(tags);
        }

        public async Task<TagDto> GetByIdAsync(int tagId)
        {
            var tag = _repository.Get(x => x.TagId == tagId).FirstOrDefault();
            return await MapDtoAsync(tag);
        }

        public async Task<TagDto> GetByNameAsync(string name)
        {
            var tag = _repository.Get(x => x.TagName == name).FirstOrDefault();
            return await MapDtoAsync(tag);
        }

        public async Task<TagDto> GetBySlugAsync(string slug)
        {
            var tag = _repository.Get(x => x.Slug == slug).FirstOrDefault();
            return await MapDtoAsync(tag);
        }

        public async Task<IEnumerable<TagDto>> GetOfBookAsync(string bookId)
        {
            var bookTags = _bookTagRepository.Get(x => x.BookId == bookId);
            var tags = new List<Tag>();
            foreach (var bookTag in bookTags)
            {
                tags.Add(_repository.Get(x => x.TagId == bookTag.TagId).FirstOrDefault());
            }
            return await MapDtosAsync(tags);
        }

        public async Task AddOfBookAsync(string bookId, IEnumerable<int> tags)
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
                    TagId = tag,
                });
            }
            _bookTagRepository.SaveAsync();
        }
    }
}