using Microsoft.EntityFrameworkCore;
using NovelWebsite.Models;

namespace NovelWebsite.Entities
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<AuthorEntity> Authors { get; set; }
        public DbSet<BookStatusEntity> BookStatuses { get; set; }
        public DbSet<BookEntity> Books { get; set; }
        public DbSet<AccountEntity> Accounts { get; set; }
        public DbSet<BookTagEntity> BookTags { get; set; }
        public DbSet<ChapterEntity> Chapters { get; set; }
        public DbSet<CommentEntity> Comments { get; set; }
        public DbSet<BookUserFollowEntity> BookUserFollows { get; set; }
        public DbSet<BookUserLikeEntity> BookUserLikes { get; set; }
        public DbSet<BookUserRecommendEntity> BookUserRecommends { get; set; }
        public DbSet<ChapterUserLikeEntity> ChapterUserLikes { get; set; }
        public DbSet<CommentUserLikeEntity> CommentUserLikes { get; set; }
        public DbSet<PostUserLikeEntity> PostUserLikes { get; set; }
        public DbSet<ReviewUserLikeEntity> ReviewUserLikes { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<RoleEntity> Roles { get; set; }
        public DbSet<PostEntity> Posts { get; set; }
        public DbSet<ReviewEntity> Reviews { get; set; }
        public DbSet<TagEntity> Tags { get; set; }
        public DbSet<BannerEntity> Banners { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryEntity>().ToTable("Category");
            modelBuilder.Entity<AuthorEntity>().ToTable("Author");
            modelBuilder.Entity<BookStatusEntity>().ToTable("BookStatus");
            modelBuilder.Entity<BookEntity>().ToTable("Book");
            modelBuilder.Entity<AccountEntity>().ToTable("Account");
            modelBuilder.Entity<TagEntity>().ToTable("Tag");
            modelBuilder.Entity<BookTagEntity>().ToTable("BookTag").HasKey(bt => new {bt.BookId, bt.TagId});
            modelBuilder.Entity<ChapterEntity>().ToTable("Chapter");
            modelBuilder.Entity<CommentEntity>().ToTable("Comment");
            modelBuilder.Entity<UserEntity>().ToTable("User");
            modelBuilder.Entity<RoleEntity>().ToTable("Role");
            modelBuilder.Entity<PostEntity>().ToTable("Post");
            modelBuilder.Entity<BookUserFollowEntity>().ToTable("BookUserFollow").HasKey(bu => new {bu.BookId, bu.UserId});
            modelBuilder.Entity<BookUserLikeEntity>().ToTable("BookUserLike").HasKey(bu => new {bu.BookId, bu.UserId});
            modelBuilder.Entity<BookUserRecommendEntity>().ToTable("BookUserRecommend").HasKey(bu => new {bu.BookId, bu.UserId});
            modelBuilder.Entity<ReviewEntity>().ToTable("Review");
            modelBuilder.Entity<BannerEntity>().ToTable("Banner");
            modelBuilder.Entity<ChapterUserLikeEntity>().ToTable("ChapterUserLike").HasKey(bu => new { bu.ChapterId, bu.UserId });
            modelBuilder.Entity<PostUserLikeEntity>().ToTable("PostUserLike").HasKey(bu => new { bu.PostId, bu.UserId });
            modelBuilder.Entity<ReviewUserLikeEntity>().ToTable("ReviewUserLike").HasKey(bu => new { bu.ReviewId, bu.UserId });
            modelBuilder.Entity<CommentUserLikeEntity>().ToTable("CommentUserLike").HasKey(bu => new { bu.CommentId, bu.UserId });
            base.OnModelCreating(modelBuilder);
        }
    }

}
