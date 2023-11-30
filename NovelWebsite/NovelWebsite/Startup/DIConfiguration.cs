using Application.Interfaces;
using Application.Services.Base;
using Domain.Interfaces.Base;
using NovelWebsite.Application.Interfaces;
using NovelWebsite.Application.Services;
using NovelWebsite.Domain.Interfaces;
using NovelWebsite.Domain.Services;
using NovelWebsite.Infrastructure.Repositories;
using NovelWebsite.Infrastructure.Repositories.Base;

namespace NovelWebsite.Startup
{
    public static class DIConfiguration
    {
        public static IServiceCollection AddDIService(this IServiceCollection services)
        {
            //services.AddScoped<IAccessService, AccessService>();
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
            //services.AddScoped(typeof(IService<>), typeof(GenericService<,>));
            //services.AddTransient<IMailService, MailService>();

            //services.AddScoped<AccessService>();
            //services.AddScoped<AuthorService>();
            //services.AddScoped<BannerService>();
            //services.AddScoped<BookService>();
            //services.AddScoped<CategoryService>();
            //services.AddScoped<ChapterService>();
            //services.AddScoped<CommentService>();
            //services.AddScoped<PostService>();
            //services.AddScoped<ReviewService>();
            //services.AddScoped<RoleService>();
            //services.AddScoped<TagService>();
            //services.AddScoped<UserService>();
            //services.AddScoped<UploadService>();
            //services.AddScoped<StatisticService>();

            services.AddScoped<IBookInteractionService, BookInteractionService>();
            services.AddScoped<IChapterInteractionService ,ChapterInteractionService>();
            services.AddScoped<IPostInteractionService, PostInteractionService>();
            services.AddScoped<IReviewInteractionService ,ReviewInteractionService>();
            services.AddScoped<ICommentInteractionService ,CommentInteractionService>();
            
            services.AddTransient<MailService>();
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
