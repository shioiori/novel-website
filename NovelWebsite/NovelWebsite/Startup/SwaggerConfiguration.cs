using Microsoft.OpenApi.Models;

namespace NovelWebsite.Startup
{
    public static class SwaggerConfiguration
    {
        public static IServiceCollection AddSwaggerGen(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v2", new OpenApiInfo { Title = "MVCCallWebAPI", Version = "v2" });
            });
            return services;
        }

        public static WebApplication AddSwaggerConfiguration(this WebApplication app)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v2/swagger.json", "MVCCallWebAPI");
                c.RoutePrefix = "";
            });

            return app;
        }
    }
}
