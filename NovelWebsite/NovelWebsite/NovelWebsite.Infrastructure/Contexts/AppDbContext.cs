using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NovelWebsite.Infrastructure.Entities;
using NovelWebsite.NovelWebsite.Infrastructure.Entities;

namespace NovelWebsite.Infrastructure.Contexts
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Book_Tag> BookTags { get; set; }
        public DbSet<Chapter> Chapters { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Book_User> BookUsers { get; set; }
        public DbSet<Chapter_User> ChapterUsers { get; set; }
        public DbSet<Comment_User> CommentUsers { get; set; }
        public DbSet<Post_User> PostUsers { get; set; }
        public DbSet<Review_User> ReviewUsers { get; set; }
        public DbSet<User> Users { get; set; }
        //public DbSet<UserLogin> UserLogins {  get; set; }
        //public DbSet<Role> Roles { get; set; }
        //public DbSet<User_Role> User_Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
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
            modelBuilder.Entity<Tag>().ToTable("Tag");
            modelBuilder.Entity<Book_Tag>().ToTable("BookTag").HasKey(bt => new { bt.BookId, bt.TagId });
            modelBuilder.Entity<Chapter>().ToTable("Chapter");
            modelBuilder.Entity<Comment>().ToTable("Comment");
            modelBuilder.Entity<User>().ToTable("User");
            //modelBuilder.Entity<UserLogin>().ToTable("UserLogin").HasKey(x => new { x.ProviderKey, x.LoginProvider });
            //modelBuilder.Entity<Role>().ToTable("Role");
            modelBuilder.Entity<Permission>().ToTable("Permission");
            modelBuilder.Entity<Post>().ToTable("Post");
            modelBuilder.Entity<Review>().ToTable("Review");
            modelBuilder.Entity<Banner>().ToTable("Banner");
            modelBuilder.Entity<Interaction>().ToTable("Interaction");
            modelBuilder.Entity<Book_User>().ToTable("Book_User").HasKey(bu => new { bu.BookId, bu.UserId, bu.InteractType });
            modelBuilder.Entity<Chapter_User>().ToTable("Chapter_User").HasKey(bu => new { bu.ChapterId, bu.UserId, bu.InteractType });
            modelBuilder.Entity<Post_User>().ToTable("Post_User").HasKey(bu => new { bu.PostId, bu.UserId, bu.InteractType });
            modelBuilder.Entity<Review_User>().ToTable("Review_User").HasKey(bu => new { bu.ReviewId, bu.UserId, bu.InteractType });
            modelBuilder.Entity<User_Role>().ToTable("User_Role").HasKey(bu => new { bu.UserId, bu.RoleId });
            modelBuilder.Entity<Comment_User>().ToTable("Comment_User").HasKey(bu => new { bu.CommentId, bu.UserId, bu.InteractType, bu.ReplyCommentId });
            modelBuilder.Entity<Role_Permission>().ToTable("Role_Permission").HasKey(bu => new { bu.RoleId, bu.PermissionId });
            
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
