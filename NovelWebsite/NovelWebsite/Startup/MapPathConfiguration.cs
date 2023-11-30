namespace NovelWebsite.Startup
{
    public static class MapPathConfiguration
    {
        public static IServiceCollection AddMVCViewsPathConfiguration(this IServiceCollection services)
        {
            services.AddMvc()
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
            return services;
        }
    }
}
