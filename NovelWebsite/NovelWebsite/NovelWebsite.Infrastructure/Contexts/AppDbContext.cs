using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NovelWebsite.NovelWebsite.Infrastructure.Entities;
using NovelWebsite.NovelWebsite.NovelWebsite.Infrastructure.Entities;

namespace NovelWebsite.Infrastructure.Contexts
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookTags> BookTags { get; set; }
        public DbSet<Chapter> Chapters { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<BookUsers> BookUsers { get; set; }
        public DbSet<ChapterUsers> ChapterUsers { get; set; }
        public DbSet<CommentUsers> CommentUsers { get; set; }
        public DbSet<PostUsers> PostUsers { get; set; }
        public DbSet<ReviewUsers> ReviewUsers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<Interaction> Interactions { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Interaction>().ToTable("Interactions");
            modelBuilder.Entity<Category>().ToTable("Categories");
            modelBuilder.Entity<Author>().ToTable("Authors");
            modelBuilder.Entity<Book>(builder =>
            {
                builder.ToTable("Books");
                builder.Navigation(e => e.Category).AutoInclude();
                builder.Navigation(e => e.Author).AutoInclude();
                builder.Navigation(e => e.User).AutoInclude();
            });   
            modelBuilder.Entity<Tag>().ToTable("Tags");
            modelBuilder.Entity<BookTags>().ToTable("BookTags").HasKey(bt => new { bt.BookId, bt.TagId });
            modelBuilder.Entity<Chapter>(builder =>
            {
                builder.ToTable("Chapters");
                builder.Navigation(e => e.Book).AutoInclude();
            });
            modelBuilder.Entity<Comment>(builder =>
            {
                builder.ToTable("Comments");
                builder.Navigation(e => e.User).AutoInclude();
            }); 
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Permission>().ToTable("Permissions");
            modelBuilder.Entity<Post>(builder => {
                builder.ToTable("Posts");
                builder.Navigation(e => e.User).AutoInclude();
            });
            modelBuilder.Entity<Review>(builder =>
            {
                builder.ToTable("Reviews");
                builder.Navigation(e => e.User).AutoInclude();
                builder.Navigation(e => e.Book).AutoInclude();
            });
            modelBuilder.Entity<Banner>().ToTable("Banners");
            modelBuilder.Entity<BookUsers>().ToTable("BookUsers").HasKey(bu => new { bu.BookId, bu.UserId, bu.InteractionId });
            modelBuilder.Entity<ChapterUsers>().ToTable("ChapterUsers").HasKey(bu => new { bu.ChapterId, bu.UserId, bu.InteractionId });
            modelBuilder.Entity<PostUsers>().ToTable("PostUsers").HasKey(bu => new { bu.PostId, bu.UserId, bu.InteractionId });
            modelBuilder.Entity<ReviewUsers>().ToTable("ReviewUsers").HasKey(bu => new { bu.ReviewId, bu.UserId, bu.InteractionId });
            modelBuilder.Entity<CommentUsers>().ToTable("CommentUsers").HasKey(bu => new { bu.CommentId, bu.UserId, bu.InteractionId });
            modelBuilder.Entity<RolePermissions>().ToTable("RolePermissions").HasKey(bu => new { bu.RoleId, bu.PermissionId });
            
            base.OnModelCreating(modelBuilder);
            // Bỏ tiền tố AspNet của các bảng: mặc định các bảng trong IdentityDbContext có
            // tên với tiền tố AspNet như: AspNetUserRoles, AspNetUser ...
            // Đoạn mã sau chạy khi khởi tạo DbContext, tạo database sẽ loại bỏ tiền tố đó
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var tableName = entityType.GetTableName();
                if (tableName.StartsWith("AspNet"))
                {
                    entityType.SetTableName(tableName.Substring(6));
                }
            }
        }
    }

}
