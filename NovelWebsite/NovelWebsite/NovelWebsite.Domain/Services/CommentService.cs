using AutoMapper;
using NovelWebsite.Infrastructure.Entities;
using NovelWebsite.NovelWebsite.Core.Interfaces.Repositories;
using NovelWebsite.NovelWebsite.Core.Interfaces.Services;
using NovelWebsite.NovelWebsite.Core.Models;

namespace NovelWebsite.NovelWebsite.Domain.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly ICommentUserRepository _commentUserRepository;
        private readonly IMapper _mapper;

        public CommentService(ICommentRepository commentRepository, ICommentUserRepository commentUserRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _commentUserRepository = commentUserRepository;
            _mapper = mapper;
        }

        public CommentModel GetComment(int commentId)
        {
            var comment = _commentRepository.GetById(commentId);
            return _mapper.Map<Comment, CommentModel>(comment);
        }

        public IEnumerable<CommentModel> GetCommentsOfBook(int bookId)
        {
            var comments = _commentRepository.Filter(x => x.BookId == bookId);
            return _mapper.Map<IEnumerable<Comment>, IEnumerable<CommentModel>>(comments);
        }

        public IEnumerable<CommentModel> GetCommentsOfPost(int postId)
        {
            var comments = _commentRepository.Filter(x => x.PostId == postId);
            return _mapper.Map<IEnumerable<Comment>, IEnumerable<CommentModel>>(comments);
        }

        public IEnumerable<CommentModel> GetCommentsOfChapter(int chapterId)
        {

            var comments = _commentRepository.Filter(x => x.ChapterId == chapterId);
            return _mapper.Map<IEnumerable<Comment>, IEnumerable<CommentModel>>(comments);
        }

        public IEnumerable<CommentModel> GetCommentsOfReview(int reviewId)
        {
            var comments = _commentRepository.Filter(x => x.ReviewId == reviewId);
            return _mapper.Map<IEnumerable<Comment>, IEnumerable<CommentModel>>(comments);
        }

        public IEnumerable<CommentModel> GetReplyComments(int commentId)
        {
            var comments = _commentUserRepository.Filter(x => x.InteractType == InteractionType.Comment);
            return _mapper.Map<IEnumerable<Comment>, IEnumerable<CommentModel>>(comments);
        }

        public void CreateComment(CommentModel comment)
        {
            _commentRepository.Insert(_mapper.Map<CommentModel, Comment>(comment));
        }

        public void UpdateComment(CommentModel comment)
        {
            _commentRepository.Update(_mapper.Map<CommentModel, Comment>(comment));
        }

        public void DeleteComment(int commentId)
        {
            _commentRepository.Delete(commentId);
        }
    }
}