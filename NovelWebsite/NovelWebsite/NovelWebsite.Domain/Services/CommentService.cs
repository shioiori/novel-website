using AutoMapper;
using NovelWebsite.NovelWebsite.Infrastructure.Entities;
using NovelWebsite.NovelWebsite.Core.Enums;
using NovelWebsite.NovelWebsite.Core.Interfaces.Repositories;
using NovelWebsite.NovelWebsite.Core.Interfaces.Services;
using NovelWebsite.NovelWebsite.Core.Models;

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

        public CommentModel GetComment(string commentId)
        {
            var comment = _commentRepository.GetById(commentId);
            return _mapper.Map<Comment, CommentModel>(comment);
        }

        public IEnumerable<CommentModel> GetCommentsOfBook(string bookId)
        {
            var comments = _commentRepository.Filter(x => x.BookId == bookId);
            return _mapper.Map<IEnumerable<Comment>, IEnumerable<CommentModel>>(comments);
        }

        public IEnumerable<CommentModel> GetCommentsOfPost(string postId)
        {
            var comments = _commentRepository.Filter(x => x.PostId == postId);
            return _mapper.Map<IEnumerable<Comment>, IEnumerable<CommentModel>>(comments);
        }

        public IEnumerable<CommentModel> GetCommentsOfChapter(string chapterId)
        {

            var comments = _commentRepository.Filter(x => x.ChapterId == chapterId);
            return _mapper.Map<IEnumerable<Comment>, IEnumerable<CommentModel>>(comments);
        }

        public IEnumerable<CommentModel> GetCommentsOfReview(string reviewId)
        {
            var comments = _commentRepository.Filter(x => x.ReviewId == reviewId);
            return _mapper.Map<IEnumerable<Comment>, IEnumerable<CommentModel>>(comments);
        }

        public IEnumerable<CommentModel> GetReplyComments(string commentId)
        {
            var comments = _commentUserRepository.Filter(x => x.ReplyCommentId == commentId && x.InteractionId == (int)InteractionType.Comment).ToList();
            List<CommentModel> cmts = new List<CommentModel>();
            foreach (var cmt in comments)
            {
                cmts.Add(_mapper.Map<Comment, CommentModel>(_commentRepository.GetById(cmt.CommentId)));
            }
            return cmts;
        }

        public void CreateComment(CommentModel comment)
        {
            var cmt = _commentRepository.Insert(_mapper.Map<CommentModel, Comment>(comment));
            if (comment.ReplyCommentId != null)
            {
                _commentUserRepository.Insert(new CommentUsers()
                {
                    CommentId = cmt.CommentId,
                    UserId = cmt.UserId,
                    InteractionId = (int)InteractionType.Comment,
                    ReplyCommentId = comment.ReplyCommentId
                });
                _commentUserRepository.Save();
            }
            _commentRepository.Save();
        }

        public void UpdateComment(CommentModel comment)
        {
            _commentRepository.Update(_mapper.Map<CommentModel, Comment>(comment));
            _commentRepository.Save();
        }

        public void DeleteComment(string commentId)
        {
            _commentRepository.Delete(commentId);
            _commentRepository.Save();
        }
    }
}