using AutoMapper;
using NovelWebsite.NovelWebsite.Infrastructure.Entities;
using NovelWebsite.NovelWebsite.Core.Enums;
using NovelWebsite.NovelWebsite.Core.Interfaces.Repositories;
using NovelWebsite.NovelWebsite.Core.Interfaces.Services;
using NovelWebsite.NovelWebsite.Core.Models;
using NovelWebsite.NovelWebsite.Core.Models.Request;
using NovelWebsite.NovelWebsite.Core.Models.Response;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace NovelWebsite.NovelWebsite.Domain.Services
{
    public class CommentService 
    {
        private readonly ICommentRepository _commentRepository;
        private readonly ICommentUserRepository _commentUserRepository;
        private readonly IMapper _mapper;

        public CommentService(ICommentRepository commentRepository, 
                ICommentUserRepository commentUserRepository ,IMapper mapper)
        {
            _commentRepository = commentRepository;
            _commentUserRepository = commentUserRepository;
            _mapper = mapper;
        }

        public async Task<CommentModel> GetCommentAsync(string commentId)
        {
            var comment = await _commentRepository.GetByIdAsync(commentId);
            return _mapper.Map<Comment, CommentModel>(comment);
        }

        public IEnumerable<CommentModel> GetCommentsOfBook(string bookId, PagedListRequest pagedListRequest = null)
        {
            var query = _commentRepository.Filter(x => x.BookId == bookId);
            var comments = PagedList<Comment>.AsEnumerable(query, pagedListRequest);
            return _mapper.Map<IEnumerable<Comment>, IEnumerable<CommentModel>>(comments);
        }

        public IEnumerable<CommentModel> GetCommentsOfPost(string postId, PagedListRequest pagedListRequest = null)
        {
            var query = _commentRepository.Filter(x => x.PostId == postId);
            var comments = PagedList<Comment>.AsEnumerable(query, pagedListRequest);
            return _mapper.Map<IEnumerable<Comment>, IEnumerable<CommentModel>>(comments);
        }

        public IEnumerable<CommentModel> GetCommentsOfChapter(string chapterId, PagedListRequest pagedListRequest = null)
        {

            var query = _commentRepository.Filter(x => x.ChapterId == chapterId);
            var comments = PagedList<Comment>.AsEnumerable(query, pagedListRequest);
            return _mapper.Map<IEnumerable<Comment>, IEnumerable<CommentModel>>(comments);
        }

        public IEnumerable<CommentModel> GetCommentsOfReview(string reviewId, PagedListRequest pagedListRequest = null)
        {
            var query = _commentRepository.Filter(x => x.ReviewId == reviewId);
            var comments = PagedList<Comment>.AsEnumerable(query, pagedListRequest);
            return _mapper.Map<IEnumerable<Comment>, IEnumerable<CommentModel>>(comments);
        }

        public async Task<IEnumerable<CommentModel>> GetReplyCommentsAsync(string commentId, PagedListRequest pagedListRequest = null)
        {
            var commentUsers = _commentUserRepository.Filter(x => x.ReplyCommentId == commentId && x.InteractionId == (int)InteractionType.Comment).AsEnumerable();
            List<Comment> comments = new List<Comment>();
            foreach (var cmt in commentUsers)
            {
                comments.Add(await _commentRepository.GetByIdAsync(cmt.CommentId));
            }
            var res = PagedList<Comment>.AsEnumerable(comments, pagedListRequest);
            return _mapper.Map<IEnumerable<Comment>, IEnumerable<CommentModel>>(res);
        }

        public async Task CreateCommentAsync(CommentModel comment)
        {
            var cmt = await _commentRepository.InsertAsync(_mapper.Map<CommentModel, Comment>(comment));
            if (comment.ReplyCommentId != null)
            {
                await _commentUserRepository.InsertAsync(new CommentUsers()
                {
                    CommentId = cmt.CommentId,
                    UserId = cmt.UserId,
                    InteractionId = (int)InteractionType.Comment,
                    ReplyCommentId = comment.ReplyCommentId
                });
                _commentUserRepository.SaveAsync();
            }
            _commentRepository.SaveAsync();
        }

        public async Task UpdateCommentAsync(CommentModel comment)
        {
            await _commentRepository.UpdateAsync(_mapper.Map<CommentModel, Comment>(comment));
            _commentRepository.SaveAsync();
        }

        public async Task DeleteCommentAsync(string commentId)
        {
            await _commentRepository.DeleteAsync(commentId);
            _commentRepository.SaveAsync();
        }
    }
}