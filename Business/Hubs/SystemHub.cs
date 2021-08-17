using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace Business.Hubs
{
    public class SystemHub : Hub
    {
        public override async Task OnConnectedAsync()
        {
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
        }
    }
}