namespace NovelWebsite.NovelWebsite.Startup
{
    public static class EndpointsConfiguration
    {
        public static WebApplication MapEndpointsConfiguration(this WebApplication app)
        {
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "mvc/{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                  name: "default",
                  pattern: "mvc/{controller=Home}/{action=Index}/{id?}");

            });

            return app;
        }
    }
}
