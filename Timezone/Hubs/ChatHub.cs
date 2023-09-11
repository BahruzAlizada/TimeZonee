using Microsoft.AspNetCore.SignalR;

namespace Timezone.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string toUserId,string message)
        {
            string fromUserId = Context.ConnectionId;

            await Clients.Client(fromUserId).SendAsync("ReceiveMessage", toUserId, message);
        }
    }
}
