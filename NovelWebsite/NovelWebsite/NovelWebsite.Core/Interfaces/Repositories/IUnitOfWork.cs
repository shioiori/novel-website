using NovelWebsite.Infrastructure.Contexts;
using NovelWebsite.NovelWebsite.Core.Interfaces.Repositories;

public interface IUnitOfWork
    {
        IAuthorRepository AuthorRepository{ get; }
        IBannerRepository BannerRepository{ get; }
        IBookRepository BookRepository{ get; }
        IBookTagRepository BookTagRepository{ get; }
        IBookUserRepository BookUserRepository{ get; }
        ICategoryRepository CategoryRepository{ get; }
        IChapterRepository ChapterRepository{ get; }
        IChapterUserRepository ChapterUserRepository{ get; }
        ICommentRepository CommentRepository{ get; }
        ICommentUserRepository CommentUserRepository{ get; }
        IPostRepository PostRepository{ get; }
        IPostUserRepository PostUserRepository{ get; }
        IReviewRepository ReviewRepository{ get; }
        IReviewUserRepository ReviewUserRepository{ get; }
        IRoleRepository RoleRepository{ get; }
        ITagRepository TagRepository{ get; }
        IUserRepository UserRepository{ get; }            
        Task<int> CompleteAsync();
        int Complete();
    }