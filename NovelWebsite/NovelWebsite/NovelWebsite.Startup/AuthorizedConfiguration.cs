using NovelWebsite.Domain.Authorization;
using System.Security.Claims;

namespace NovelWebsite.NovelWebsite.Startup
{
    public static class AuthorizedConfiguration
    {
        public static IServiceCollection AddAuthorizedConfiguration (this IServiceCollection services)
        {
            services.AddAuthorization(options =>
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
            return services;
        }
    }
}
