using Microsoft.AspNetCore.Authentication.Cookies;

namespace NovelWebsite.NovelWebsite.Startup
{
    public static class AuthenticatedConfiguration
    {
        public static IServiceCollection AddAuthenticatedConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
            {
                options.LoginPath = "/Admin/Account/Login";
            });
            services.AddAuthentication().AddGoogle(googleOptions =>
            {
                IConfigurationSection googleAuthNSection = configuration.GetSection("Authentication:Google");
                googleOptions.ClientId = configuration["Authentication:Google:ClientId"];
                googleOptions.ClientSecret = configuration["Authentication:Google:ClientSecret"];
            }).AddFacebook(facebookOptions =>
            {
                facebookOptions.AppId = configuration["Authentication:Facebook:AppId"];
                facebookOptions.AppSecret = configuration["Authentication:Facebook:AppSecret"];
                facebookOptions.AccessDeniedPath = "/Error/Log";
            });
            return services;
        }
    }
}
