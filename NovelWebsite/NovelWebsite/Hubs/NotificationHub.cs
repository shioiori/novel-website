using Microsoft.AspNetCore.SignalR;
using NovelWebsite.Provider;

namespace NovelWebsite.Hubs
{
    public class NotificationHub : Hub
    {
        /*private readonly UsernameBasedUserIdProvider _usernameProvider;

        public NotificationHub(UsernameBasedUserIdProvider basedUserIdProvider) 
        {
            _usernameProvider = basedUserIdProvider;
        }*/


        public async Task SendNotification(string message)
        {
            await Clients.All.SendAsync("ReceiveNotification", "anonymous", message);
        }

        public async Task SendUserNotification(string sender, string receiver, string message)
        {
            await Clients.User(receiver).SendAsync("ReceiveUserNotification", sender, receiver, message);
        }

        public override async Task OnConnectedAsync()
        {
            await Clients.All.SendAsync("UserConnection", Context.ConnectionId);
            await base.OnConnectedAsync(); 
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            await Clients.All.SendAsync("UserDisconnection", Context.ConnectionId);
            await base.OnDisconnectedAsync(exception);
        }
    }
}
