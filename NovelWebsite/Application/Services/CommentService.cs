using NovelWebsite.Application.Models.Request;
using Application.Utils;
using Application.Models.Dtos;
using NovelWebsite.Domain.Interfaces;
using Application.Services.Base;
using NovelWebsite.Domain.Entities;
using NovelWebsite.Domain.Enums;
using AutoMapper;
using Application.Models.Filters;
using Application.Interfaces;

namespace NovelWebsite.Application.Services
{
    public class CommentService : GenericService<Comment, CommentDto>, ICommentService
    {
        private readonly ICommentUserRepository _commentUserRepository;

        public CommentService(ICommentUserRepository commentUserRepository,
            ICommentRepository commentRepository,
            IMapper mapper) : base(commentRepository, mapper)
        {
            _commentUserRepository = commentUserRepository;
        }

        public async Task<CommentDto> GetByIdAsync(string commentId)
        {
            var comment = _repository.Get(x => x.CommentId == commentId).FirstOrDefault();
            return await MapDtoAsync(comment);
        }

        public async Task<IEnumerable<CommentDto>> FilterAsync(CommentFilter filter, PagedListRequest request)
        {
            var query = _repository.Get();
            if (filter == null)
            {
                return await MapDtosAsync(query.AsEnumerable());
            }
            if (filter.BookId != null)
            {
                query = query.Where(x => x.BookId == filter.BookId);
            }
            if (filter.ChapterId != null)
            {
                query = query.Where(x => x.ChapterId == filter.ChapterId);
            }
            if (filter.PostId != null)
            {
                query = query.Where(x => x.PostId == filter.PostId);
            }
            if (filter.ReviewId != null)
            {
                query = query.Where(x => x.ReviewId == filter.ReviewId);
            }
            var comments = PagedList<Comment>.AsEnumerable(query, request);
            return await MapDtosAsync(comments);
        }

        public async Task<IEnumerable<CommentDto>> GetRepliesAsync(string commentId, PagedListRequest pagedListRequest)
        {
            var commentUsers = _commentUserRepository.Get(x => x.ReplyCommentId == commentId && x.InteractionId == (int)InteractionType.Comment);
            List<Comment> comments = new List<Comment>();
            foreach (var cmt in commentUsers)
            {
                comments.Add(_repository.Get(x => x.CommentId == cmt.CommentId).FirstOrDefault());
            }
            var res = PagedList<Comment>.AsEnumerable(comments, pagedListRequest);
            return await MapDtosAsync(res);
        }

        public override async Task<CommentDto> AddAsync(CommentDto dto)
        {
            var comment = await _repository.InsertAsync(await MapEntityAsync(dto));
            if (dto.ReplyCommentId != null)
            {
                await _commentUserRepository.InsertAsync(new CommentUsers()
                {
                    CommentId = comment.CommentId,
                    UserId = comment.UserId,
                    InteractionId = (int)InteractionType.Comment,
                    ReplyCommentId = dto.ReplyCommentId
                });
            }
            _repository.SaveAsync();
            return await MapDtoAsync(comment);
        }
    }
}