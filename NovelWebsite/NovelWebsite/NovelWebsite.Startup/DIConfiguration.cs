using Microsoft.AspNetCore.Identity;
using NovelWebsite.Domain.Services;
using NovelWebsite.Infrastructure.Entities;
using NovelWebsite.NovelWebsite.Core.Interfaces;
using NovelWebsite.NovelWebsite.Core.Interfaces.Repositories;
using NovelWebsite.NovelWebsite.Core.Interfaces.Services;
using NovelWebsite.NovelWebsite.Domain.Services;
using NovelWebsite.NovelWebsite.Infrastructure.Entities;
using NovelWebsite.NovelWebsite.Infrastructure.Repositories;

namespace NovelWebsite.NovelWebsite.Startup
{
    public static class DIConfiguration
    {
        public static IServiceCollection AddDIService(this IServiceCollection services)
        {
            services.AddScoped<IAccessService, AccessService>();
            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<IBannerService, BannerService>();
            services.AddScoped<IBookService, BookService>();
            //services.AddScoped<IBookTagService, BookTagService>();
            //services.AddScoped<IBookUserService, BookUserService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IChapterService, ChapterService>();
            //services.AddScoped<IChapterUserService, ChapterUserService>();
            services.AddScoped<ICommentService, CommentService>();
            //services.AddScoped<ICommentUserService, CommentUserService>();
            services.AddScoped<IPostService, PostService>();
            //services.AddScoped<IPostUserService, PostUserService>();
            services.AddScoped<IReviewService, ReviewService>();
            //services.AddScoped<IReviewUserService, ReviewUserService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<ITagService, TagService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IStatisticService, StatisticService>();

            services.AddTransient<IMailService, MailService>();
            return services;
        }

        public static IServiceCollection AddDIRepository(this IServiceCollection services)
        {

            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IBannerRepository, BannerRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IBookTagRepository, BookTagRepository>();
            services.AddScoped<IBookUserRepository, BookUserRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IChapterRepository, ChapterRepository>();
            services.AddScoped<IChapterUserRepository, ChapterUserRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<ICommentUserRepository, CommentUserRepository>();
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<IPostUserRepository, PostUserRepository>();
            services.AddScoped<IReviewRepository, ReviewRepository>();
            services.AddScoped<IReviewUserRepository, ReviewUserRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<ITagRepository, TagRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRolePermissionRepository, RolePermissionRepository>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            return services;
        }
    }
}
