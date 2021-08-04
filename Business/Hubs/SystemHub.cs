using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace Business.Hubs
{
    public class SystemHub : Hub
    {
        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            return base.OnDisconnectedAsync(exception);
        }
    }
}