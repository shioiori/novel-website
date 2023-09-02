using Microsoft.AspNetCore.Authorization;
using NovelWebsite.Entities;
using NovelWebsite.Models;

namespace NovelWebsite.Domain.Authorization
{
    public class BookOwnerRequirement : IAuthorizationRequirement
    {
        public BookOwnerRequirement()
        {
        }

    }
}
