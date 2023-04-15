using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using NovelWebsite.Authorization;
using NovelWebsite.Entities;
using System.Configuration;
using System.Net;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
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

builder.Services.AddTransient<IAuthorizationHandler, CheckBookOwnerAuthorizationHandler>();

builder.Services.AddHttpContextAccessor();
builder.Services.AddDistributedMemoryCache();           
builder.Services.AddSession(cfg => {                   
    cfg.Cookie.Name = "novelwebsite";             
    cfg.IdleTimeout = new TimeSpan(0, 30, 0);    
});

builder.Services.AddSingleton<IHostedService, CacheUpdateService>();
builder.Services.AddMemoryCache();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseStatusCodePagesWithRedirects("/Error/{0}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

    endpoints.MapControllerRoute(
      name: "default",
      pattern: "{controller=Home}/{action=Index}/{id?}");

    endpoints.MapControllerRoute(
      name: "reviews",
      pattern: "review/{categoryId?}",
      defaults: new { controller = "Review", action = "Index"});

    endpoints.MapControllerRoute(
     name: "filter",
     pattern: "bo-loc/",
     defaults: new { controller = "Filter", action = "Index" });
});

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
