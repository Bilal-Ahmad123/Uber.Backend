
using Microsoft.AspNetCore.SignalR;
using Uber.Application.Models;

namespace Uber.Backend.Presentation.SignalR.Hubs;
public sealed class LocationHub:Hub
{
    public async Task SendMessage(Location location)
    {
        await Clients.All.SendAsync("Send",location);
    }
}
