using Microsoft.EntityFrameworkCore;
using NovelWebsite.Infrastructure.Entities;

namespace NovelWebsite.Infrastructure.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<BookStatusEntity> BookStatuses { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Book_Tag> BookTags { get; set; }
        public DbSet<Chapter> Chapters { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Book_User> BookUserFollows { get; set; }
        public DbSet<BookUserLikeEntity> BookUserLikes { get; set; }
        public DbSet<BookUserRecommendEntity> BookUserRecommends { get; set; }
        public DbSet<ChapterUserLikeEntity> ChapterUserLikes { get; set; }
        public DbSet<CommentUserLikeEntity> CommentUserLikes { get; set; }
        public DbSet<PostUserLikeEntity> PostUserLikes { get; set; }
        public DbSet<ReviewUserLikeEntity> ReviewUserLikes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Banner> Banners { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().ToTable("Category");
            modelBuilder.Entity<Author>().ToTable("Author");
            modelBuilder.Entity<BookStatusEntity>().ToTable("BookStatus");
            modelBuilder.Entity<Book>().ToTable("Book");
            modelBuilder.Entity<Account>().ToTable("Account");
            modelBuilder.Entity<Tag>().ToTable("Tag");
            modelBuilder.Entity<Book_Tag>().ToTable("BookTag").HasKey(bt => new { bt.BookId, bt.TagId });
            modelBuilder.Entity<Chapter>().ToTable("Chapter");
            modelBuilder.Entity<Comment>().ToTable("Comment");
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Role>().ToTable("Role");
            modelBuilder.Entity<Post>().ToTable("Post");
            modelBuilder.Entity<Book_User>().ToTable("BookUserFollow").HasKey(bu => new { bu.BookId, bu.UserId });
            modelBuilder.Entity<BookUserLikeEntity>().ToTable("BookUserLike").HasKey(bu => new { bu.BookId, bu.UserId });
            modelBuilder.Entity<BookUserRecommendEntity>().ToTable("BookUserRecommend").HasKey(bu => new { bu.BookId, bu.UserId });
            modelBuilder.Entity<Review>().ToTable("Review");
            modelBuilder.Entity<Banner>().ToTable("Banner");
            modelBuilder.Entity<ChapterUserLikeEntity>().ToTable("ChapterUserLike").HasKey(bu => new { bu.ChapterId, bu.UserId });
            modelBuilder.Entity<PostUserLikeEntity>().ToTable("PostUserLike").HasKey(bu => new { bu.PostId, bu.UserId });
            modelBuilder.Entity<ReviewUserLikeEntity>().ToTable("ReviewUserLike").HasKey(bu => new { bu.ReviewId, bu.UserId });
            modelBuilder.Entity<CommentUserLikeEntity>().ToTable("CommentUserLike").HasKey(bu => new { bu.CommentId, bu.UserId });
            base.OnModelCreating(modelBuilder);
        }
    }

}
