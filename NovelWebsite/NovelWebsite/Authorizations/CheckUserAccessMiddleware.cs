namespace NovelWebsite.Middleware
{
    public class CheckUserAccessMiddleware : IMiddleware
    {
        private readonly RequestDelegate _next;
        public CheckUserAccessMiddleware(RequestDelegate next) => _next = next;

        public Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            throw new NotImplementedException();
        }
    }
}
