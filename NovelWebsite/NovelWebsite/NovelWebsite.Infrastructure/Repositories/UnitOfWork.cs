
using NovelWebsite.Infrastructure.Contexts;
using NovelWebsite.NovelWebsite.Core.Interfaces.Repositories;

namespace NovelWebsite.NovelWebsite.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork{
        private readonly AppDbContext _dbContext;
        private IAccountRepository _accountRepository;
        private IAuthorRepository _authorRepository;
        private IBannerRepository _bannerRepository;
        private IBookRepository _bookRepository;
        private IBookTagRepository _bookTagRepository;
        private IBookUserRepository _bookUserRepository;
        private ICategoryRepository _categoryRepository;
        private IChapterRepository _chapterRepository;
        private IChapterUserRepository _chapterUserRepository;
        private ICommentRepository _commentRepository;
        private ICommentUserRepository _commentUserRepository;
        private IPostRepository _postRepository;
        private IPostUserRepository _postUserRepository;
        private IReviewRepository _reviewRepository;
        private IReviewUserRepository _reviewUserRepository;
        private IRoleRepository _roleRepository;
        private ITagRepository _tagRepository;
        private IUserRepository _userRepository;

        public UnitOfWork(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IAccountRepository AccountRepository
        {
            get
            {
                if (_accountRepository == null)
                {
                    _accountRepository = new AccountRepository(_dbContext);
                }
                return _accountRepository;
            }
        }

        public IAuthorRepository AuthorRepository
        {
            get
            {
                if (_authorRepository == null)
                {
                    _authorRepository = new AuthorRepository(_dbContext);
                }
                return _authorRepository;
            }
        }

        public IBannerRepository BannerRepository
        {
            get 
            {
                if (_bannerRepository == null)
                {
                    _bannerRepository = new BannerRepository(_dbContext);
                }
                return _bannerRepository;
            }
        }

        public IBookRepository BookRepository
        {
            get
            {
                if (_bookRepository == null)
                {
                    _bookRepository = new BookRepository(_dbContext);
                }
                return _bookRepository;
            }
        }

        public IBookTagRepository BookTagRepository
        {
            get 
            {
                if (_bookTagRepository == null)
                {
                    _bookTagRepository = new BookTagRepository(_dbContext);
                }
                return _bookTagRepository;
            }
        }
        
        public IBookUserRepository BookUserRepository
        {
            get
            {
                if (_bookUserRepository == null)
                {
                    _bookUserRepository = new BookUserRepository(_dbContext);
                }
                return _bookUserRepository;
            }
        }

        public ICategoryRepository CategoryRepository
        {
            get
            {
                if (_categoryRepository == null)
                {
                    _categoryRepository = new CategoryRepository(_dbContext);
                }
                return _categoryRepository;
            }
        }

        public IChapterRepository ChapterRepository
        {
            get 
            {
                if (_chapterRepository == null)
                {
                    _chapterRepository = new ChapterRepository(_dbContext);
                }
                return _chapterRepository;
            }
        }

        public IChapterUserRepository ChapterUserRepository
        {
            get
            {
                if (_chapterUserRepository == null)
                {
                    _chapterUserRepository = new ChapterUserRepository(_dbContext);
                }
                return _chapterUserRepository;
            }
        }

        public ICommentRepository CommentRepository
        {
            get
            {
                if (_commentRepository == null)
                {
                    _commentRepository = new CommentRepository(_dbContext);
                }
                return _commentRepository;
            }
        }

        public ICommentUserRepository CommentUserRepository
        {
            get
            {
                if (_commentUserRepository == null)
                {
                    _commentUserRepository = new CommentUserRepository(_dbContext);
                }
                return _commentUserRepository;
            }
        }

        public IPostRepository PostRepository
        {
            get
            {
                if (_postRepository == null)
                {
                    _postRepository = new PostRepository(_dbContext);
                }
                return _postRepository;
            }
        }

        public IPostUserRepository PostUserRepository
        {
            get
            {
                if (_postUserRepository == null)
                {
                    _postUserRepository = new PostUserRepository(_dbContext);
                }
                return _postUserRepository;
            }
        }

        public IReviewRepository ReviewRepository
        {
            get {
                if (_reviewRepository == null)
                {
                    _reviewRepository = new ReviewRepository(_dbContext);
                }
                return _reviewRepository;
            }
        }

        public IReviewUserRepository ReviewUserRepository
        {
            get
            {
                if (_reviewUserRepository == null)
                {
                    _reviewUserRepository = new ReviewUserRepository(_dbContext);
                }
                return _reviewUserRepository;
            }
        }

        public IRoleRepository RoleRepository
        {
            get
            {
                if (_roleRepository == null)
                {
                    _roleRepository = new RoleRepository(_dbContext);
                }
                return _roleRepository;
            }
        }

        public ITagRepository TagRepository
        {
            get
            {
                if (_tagRepository == null)
                {
                    _tagRepository = new TagRepository(_dbContext);
                }
                return _tagRepository;
            }
        }

        public IUserRepository UserRepository
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new UserRepository(_dbContext);
                }
                return _userRepository;
            }
        }

        public int Complete()
        {
            return _dbContext.SaveChanges();
        }

        public async Task<int> CompleteAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}