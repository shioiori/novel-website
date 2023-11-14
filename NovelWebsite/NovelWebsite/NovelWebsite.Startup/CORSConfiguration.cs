namespace NovelWebsite.NovelWebsite.Startup
{
    public static class CORSConfiguration
    {
        public static IServiceCollection AddCORSConfiguration(this IServiceCollection services, string cors)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(cors,
                                  policy =>
                                  {
                                      policy.WithOrigins("https://localhost:64082/",
                                                         "https://novel-website.somee.com/");
                                  });
            });
            return services;
        }
    }
}
