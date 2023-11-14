namespace NovelWebsite.NovelWebsite.Startup
{
    public static class APIConfiguration
    {
        public static IServiceCollection AddAPIConfiguration(this IServiceCollection services)
        {
            services.AddControllers().AddJsonOptions(jsonOptions =>
            {
                jsonOptions.JsonSerializerOptions.PropertyNamingPolicy = null;
            });
            return services;
        }
    }
}
