using Microsoft.AspNetCore.Mvc;

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
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });
            return services;
        }
    }
}
