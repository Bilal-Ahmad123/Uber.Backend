
using Microsoft.AspNetCore.SignalR;

namespace Uber.Backend.Presentation.SignalR.Hubs;
public sealed class LocationHub:Hub
{
    public async Task SendMessage(string location)
    {
        await Clients.All.SendAsync("Send",location);
    }
}
