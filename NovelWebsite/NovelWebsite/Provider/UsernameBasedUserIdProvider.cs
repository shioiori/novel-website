using Microsoft.AspNetCore.SignalR;
using System.Security.Claims;

namespace NovelWebsite.Provider
{
    public class UsernameBasedUserIdProvider : IUserIdProvider
    {
        public string? GetUserId(HubConnectionContext connection)
        {
            return connection.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }
    }
}
