using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using NovelWebsite.Domain.Authorization;
using NovelWebsite.Domain.Services;
using NovelWebsite.Infrastructure.Contexts;
using NovelWebsite.Infrastructure.Repositories;
using NovelWebsite.NovelWebsite.Core.Interfaces;
using NovelWebsite.NovelWebsite.Core.Interfaces.Repositories;
using NovelWebsite.NovelWebsite.Core.Interfaces.Services;
using NovelWebsite.NovelWebsite.Core.Models.MailKit;
using NovelWebsite.NovelWebsite.Domain.Services;
using NovelWebsite.NovelWebsite.Infrastructure.Repositories;
using System.Security.Claims;

var corsNovelWebsite = "_corsNovelWebsite";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v2", new OpenApiInfo { Title = "MVCCallWebAPI", Version = "v2" });
});

builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));

// Add services to the container.
builder.Services.AddControllers(); 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("NovelWebsite")));
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options => {
    options.LoginPath = "/Admin/Account/Login";
});

builder.Services.AddAuthentication().AddGoogle(googleOptions =>
{
    IConfigurationSection googleAuthNSection = builder.Configuration.GetSection("Authentication:Google");
    googleOptions.ClientId = builder.Configuration["Authentication:Google:ClientId"];
    googleOptions.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"];
}).AddFacebook(facebookOptions =>
{
    facebookOptions.AppId = builder.Configuration["Authentication:Facebook:AppId"];
    facebookOptions.AppSecret = builder.Configuration["Authentication:Facebook:AppSecret"];
    facebookOptions.AccessDeniedPath = "/Error/Log";
}); ;

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("UserIdentity", policy => policy.RequireAssertion(context =>
    {
        try
        {
            var role = context.User.FindFirst(ClaimTypes.Role).Value;
            if (role == "Admin" || role == "Biên tập viên")
            {
                return true;
            }
            var currentUserId = context.User.FindFirst("UserId").Value;
            var accessId = new HttpContextAccessor().HttpContext.Request.RouteValues["userId"].ToString();
            return currentUserId == accessId;
        }
        catch (Exception ex)
        {
            return false;
        }
    }));
    options.AddPolicy("BookOwner", policy => policy.Requirements.Add(new BookOwnerRequirement()));
});

builder.Services.AddDistributedMemoryCache();
builder.Services.AddMemoryCache();
builder.Services.AddSession(options =>
{
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
builder.Services.AddHttpContextAccessor();
builder.Services.AddDistributedMemoryCache();           
builder.Services.AddAutoMapper(typeof(Program));



builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<IBannerRepository, BannerRepository>();
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IBookTagRepository, BookTagRepository>();
builder.Services.AddScoped<IBookUserRepository, BookUserRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IChapterRepository, ChapterRepository>();
builder.Services.AddScoped<IChapterUserRepository, ChapterUserRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddScoped<ICommentUserRepository, CommentUserRepository>();
builder.Services.AddScoped<IPostRepository, PostRepository>();
builder.Services.AddScoped<IPostUserRepository, PostUserRepository>();
builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
builder.Services.AddScoped<IReviewUserRepository, ReviewUserRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<ITagRepository, TagRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserRoleRepository, UserRoleRepository>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<IAuthorizationService, AuthorizationService>();
//builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services.AddScoped<IBannerService, BannerService>();
//builder.Services.AddScoped<IBillboardService, BillboardService>();
builder.Services.AddScoped<IBookService, BookService>();
//builder.Services.AddScoped<IBookTagService, BookTagService>();
//builder.Services.AddScoped<IBookUserService, BookUserService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IChapterService, ChapterService>();
//builder.Services.AddScoped<IChapterUserService, ChapterUserService>();
builder.Services.AddScoped<ICommentService, CommentService>();
//builder.Services.AddScoped<ICommentUserService, CommentUserService>();
builder.Services.AddScoped<IPostService, PostService>();
//builder.Services.AddScoped<IPostUserService, PostUserService>();
builder.Services.AddScoped<IReviewService, ReviewService>();
//builder.Services.AddScoped<IReviewUserService, ReviewUserService>();
//builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<ITagService, TagService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IStatisticService, StatisticService>();


builder.Services.AddTransient<IMailService, MailService>();

builder.Services.AddMvc()
                .AddRazorOptions(options =>
                {
                    options.ViewLocationFormats.Add("/NovelWebsite.Web/Views/{1}/{0}.cshtml");
                    options.ViewLocationFormats.Add("/NovelWebsite.Web/Views/Shared/{0}.cshtml");
                    options.ViewLocationFormats.Add("/NovelWebsite.Web/Views/Shared/{1}/{0}.cshtml");
                    options.ViewLocationFormats.Add("/NovelWebsite.Web/Views/Shared/Partials/{0}.cshtml");
                    options.ViewLocationFormats.Add("/NovelWebsite.Web/Admin/Views/Shared/{1}/{0}.cshtml");
                    options.ViewLocationFormats.Add("/NovelWebsite.Web/Admin/Views/Shared/{1}/Partials/{0}.cshtml");
                    options.ViewLocationFormats.Add("/NovelWebsite.Web/Admin/Views/{1}/{0}.cshtml");
                    options.ViewLocationFormats.Add("/NovelWebsite.Web/Admin/Views/Shared/{0}.cshtml");
                })
                .AddJsonOptions(jsonOptions =>
                {
                    jsonOptions.JsonSerializerOptions.PropertyNamingPolicy = null;
                });

builder.Services.AddCors(options =>
{
    options.AddPolicy(corsNovelWebsite,
                      policy =>
                      {
                          policy.WithOrigins("https://localhost:64082/",
                                             "https://novel-website.somee.com/");
                      });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseSwagger();

// Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),        
// specifying the Swagger JSON endpoint.        
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v2/swagger.json", "MVCCallWebAPI");
});
app.UseSession();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseCors(corsNovelWebsite);
app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "mvc/{controller=Home}/{action=Index}/{id?}"
);
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "mvc/{area:exists}/{controller=Home}/{action=Index}/{id?}");

    endpoints.MapControllerRoute(
      name: "default",
      pattern: "mvc/{controller=Home}/{action=Index}/{id?}");

});
app.MapControllers();

// Create Database If Not Exists
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<AppDbContext>();
        context.Database.EnsureCreated();
    } catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred creating the DB.");
    }
}
app.Run();
