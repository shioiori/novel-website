using Microsoft.EntityFrameworkCore;
using NovelWebsite.Infrastructure.Entities;
using NovelWebsite.NovelWebsite.Infrastructure.Entities;

namespace NovelWebsite.Infrastructure.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Book_Tag> BookTags { get; set; }
        public DbSet<Chapter> Chapters { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Book_User> BookUsers { get; set; }
        public DbSet<Chapter_User> ChapterUsers { get; set; }
        public DbSet<Comment_User> CommentUsers { get; set; }
        public DbSet<Post_User> PostUsers { get; set; }
        public DbSet<Review_User> ReviewUsers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<Interaction> Interactions { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().ToTable("Category");
            modelBuilder.Entity<Author>().ToTable("Author");
            modelBuilder.Entity<Book>().ToTable("Book");
            modelBuilder.Entity<Account>().ToTable("Account");
            modelBuilder.Entity<Tag>().ToTable("Tag");
            modelBuilder.Entity<Book_Tag>().ToTable("BookTag").HasKey(bt => new { bt.BookId, bt.TagId });
            modelBuilder.Entity<Chapter>().ToTable("Chapter");
            modelBuilder.Entity<Comment>().ToTable("Comment");
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Role>().ToTable("Role");
            modelBuilder.Entity<Post>().ToTable("Post");
            modelBuilder.Entity<Review>().ToTable("Review");
            modelBuilder.Entity<Banner>().ToTable("Banner");
            modelBuilder.Entity<Interaction>().ToTable("Interaction");
            modelBuilder.Entity<Book_User>().ToTable("Book_User").HasKey(bu => new { bu.BookId, bu.UserId, bu.InteractType });
            modelBuilder.Entity<Chapter_User>().ToTable("Chapter_User").HasKey(bu => new { bu.ChapterId, bu.UserId, bu.InteractType });
            modelBuilder.Entity<Post_User>().ToTable("Post_User").HasKey(bu => new { bu.PostId, bu.UserId, bu.InteractType });
            modelBuilder.Entity<Review_User>().ToTable("Review_User").HasKey(bu => new { bu.ReviewId, bu.UserId, bu.InteractType });
            modelBuilder.Entity<Comment_User>().ToTable("Comment_User").HasKey(bu => new { bu.CommentId, bu.UserId, bu.InteractType });
            base.OnModelCreating(modelBuilder);
        }
    }

}
