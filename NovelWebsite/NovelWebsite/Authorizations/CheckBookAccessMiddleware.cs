namespace NovelWebsite.Middleware
{
    public class CheckBookAccessMiddleware : IMiddleware
    {
        private readonly RequestDelegate _next;
        public CheckBookAccessMiddleware(RequestDelegate next) => _next = next;

        public Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            throw new NotImplementedException();
        }
    }
}
