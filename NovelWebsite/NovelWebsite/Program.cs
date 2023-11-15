using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NovelWebsite.Infrastructure.Contexts;
using NovelWebsite.NovelWebsite.Core.Models.MailKit;
using NovelWebsite.NovelWebsite.Startup;

var corsNovelWebsite = "_corsNovelWebsite";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen();

builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));

// Add services to the container.
builder.Services.AddAPIConfiguration(); 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("NovelWebsite")));

builder.Services.AddAuthenticatedConfiguration(builder.Configuration);
builder.Services.AddAuthorizedConfiguration();
builder.Services.AddIdentityConfiguration(builder.Configuration);
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

builder.Services.AddDIRepository();
builder.Services.AddDIService();

builder.Services.AddMVCViewsPathConfiguration();

builder.Services.AddCORSConfiguration(corsNovelWebsite);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseSwagger();
app.AddSwaggerConfiguration();
app.UseSession();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseCors(corsNovelWebsite);
//app.UseIdentityServer();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "mvc/{controller=Home}/{action=Index}/{id?}"
);
app.MapEndpointsConfiguration();
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
