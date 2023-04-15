using Microsoft.AspNetCore.Authorization;
using NovelWebsite.Entities;
using System.Security.Claims;

namespace NovelWebsite.Authorization
{
    public class CheckBookOwnerAuthorizationHandler : AuthorizationHandler<BookOwnerRequirement>
    {
        private readonly AppDbContext _dbContext;

        public CheckBookOwnerAuthorizationHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, BookOwnerRequirement requirement)
        {
            var claims = context.User.Identity as ClaimsIdentity;
            var role = claims.FindFirst(ClaimTypes.Role).Value;
            if (role == "Admin" || role == "Biên tập viên")
            {
                context.Succeed(requirement);
                return Task.CompletedTask;
            }
            string bookId = "";
            try
            {
                bookId = new HttpContextAccessor().HttpContext.Request.RouteValues["bookId"].ToString();
            }
            catch (Exception ex)
            {
                context.Succeed(requirement);
                return Task.CompletedTask;
            }
            var bookUser = _dbContext.Books.Where(b => b.BookId == Int32.Parse(bookId)).FirstOrDefault();
            if (bookUser == null)
            {
                return Task.CompletedTask;
            }
            var bookUserId = bookUser.UserId.ToString();
            var currentUserId = new HttpContextAccessor().HttpContext.Request.RouteValues["userId"].ToString();
            if (bookUserId == currentUserId)
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }

    }
}
