using NovelWebsite.Application.Models.Request;
using Application.Utils;
using Application.Models.Dtos;
using NovelWebsite.Domain.Entities;
using Application.Services.Base;
using NovelWebsite.Domain.Interfaces;

namespace NovelWebsite.Application.Services
{
    public class TagService : GenericService<Tag, TagDto>
    {
        private readonly IBookTagRepository _bookTagRepository;
        public TagService(IBookTagRepository bookTagRepository) : base()
        {
            _bookTagRepository = bookTagRepository;
        }
        public async Task<IEnumerable<TagDto>> GetAllAsync(PagedListRequest pagedListRequest = null)
        {
            var query = _repository.Get();
            var tags = PagedList<Tag>.AsEnumerable(query, pagedListRequest);
            return await MapDtosAsync(tags);
        }

        public async Task<TagDto> GetByIdAsync(int tagId){
            var tag = _repository.Get(x => x.TagId == tagId).FirstOrDefault();
            return await MapDtosAsync(tag);
        }

        public async Task<TagDto> GetTagByNameAsync(string name)
        {
            var tag = _repository.Get(x => x.TagName == name).FirstOrDefault();
            return await MapDtosAsync(tag);
        }

        public async Task<TagDto> GetTagBySlugAsync(string slug)
        {
            var tag = _repository.Get(x => x.Slug == slug).FirstOrDefault();
            return await MapDtosAsync(tag);
        }

        public async Task<IEnumerable<TagDto>> GetTagsOfBookAsync(string bookId, PagedListRequest pagedListRequest = null)
        {
            var bookTags = _bookTagRepository.Get(x => x.BookId == bookId);
            var tags = new List<Tag>();
            foreach (var bookTag in bookTags)
            {
                tags.Add(_repository.Get(x => x.TagId == bookTag.TagId).FirstOrDefault());
            }
            return await MapDtosAsync(tags);
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