using NovelWebsite.Application.Models.Request;
using Application.Utils;
using Application.Models.Dtos;
using NovelWebsite.Domain.Interfaces;
using Application.Services.Base;
using NovelWebsite.Domain.Entities;
using NovelWebsite.Domain.Enums;

namespace NovelWebsite.Application.Services
{
    public class CommentService : GenericService<Comment, CommentDto>
    {
        private readonly ICommentUserRepository _commentUserRepository;

        public CommentService(ICommentUserRepository commentUserRepository) : base()
        {
            _commentUserRepository = commentUserRepository;
        }

        public async Task<CommentDto> GetCommentAsync(string commentId)
        {
            var comment = _repository.Get(x => x.CommentId == commentId).FirstOrDefault();
            return await MapDtosAsync(comment);
        }

        public async Task<IEnumerable<CommentDto>> GetCommentsOfBookAsync(string bookId, PagedListRequest pagedListRequest = null)
        {
            var query = _repository.Get(x => x.BookId == bookId);
            var comments = PagedList<Comment>.AsEnumerable(query, pagedListRequest);
            return await MapDtosAsync(comments);
        }

        public async Task<IEnumerable<CommentDto>> GetCommentsOfPostAsync(string postId, PagedListRequest pagedListRequest = null)
        {
            var query = _repository.Get(x => x.PostId == postId);
            var comments = PagedList<Comment>.AsEnumerable(query, pagedListRequest);
            return await MapDtosAsync(comments);
        }

        public async Task<IEnumerable<CommentDto>> GetCommentsOfChapterAsync(string chapterId, PagedListRequest pagedListRequest = null)
        {

            var query = _repository.Get(x => x.ChapterId == chapterId);
            var comments = PagedList<Comment>.AsEnumerable(query, pagedListRequest);
            return await MapDtosAsync(comments);
        }

        public async Task<IEnumerable<CommentDto>> GetCommentsOfReviewAsync(string reviewId, PagedListRequest pagedListRequest = null)
        {
            var query = _repository.Get(x => x.ReviewId == reviewId);
            var comments = PagedList<Comment>.AsEnumerable(query, pagedListRequest);
            return await MapDtosAsync(comments);
        }

        public async Task<IEnumerable<CommentDto>> GetReplyCommentsAsync(string commentId, PagedListRequest pagedListRequest = null)
        {
            var commentUsers = _commentUserRepository.Get(x => x.ReplyCommentId == commentId && x.InteractionId == (int)InteractionType.Comment).AsEnumerable();
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
                    CommentId = dto.CommentId,
                    UserId = dto.UserId,
                    InteractionId = (int)InteractionType.Comment,
                    ReplyCommentId = dto.ReplyCommentId
                });
            }
            _repository.SaveAsync();
            return await MapDtosAsync(comment);
        }
    }
}