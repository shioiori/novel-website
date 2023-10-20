using Microsoft.AspNetCore.Authorization;

namespace NovelWebsite.Domain.Authorization
{
    public class BookOwnerRequirement : IAuthorizationRequirement
    {
        public BookOwnerRequirement()
        {
        }

    }
}
