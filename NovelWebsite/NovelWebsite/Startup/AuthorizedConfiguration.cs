using System.Security.Claims;

namespace NovelWebsite.Startup
{
    public static class AuthorizedConfiguration
    {
        public static IServiceCollection AddAuthorizedConfiguration (this IServiceCollection services)
        {
            services.AddAuthorization();
            return services;
        }
    }
}
