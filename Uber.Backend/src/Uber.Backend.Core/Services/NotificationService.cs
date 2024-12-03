using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using Uber.Backend.Core.Interfaces;
using Uber.Backend;
using Uber.Backend.Core;

public class NotificationService : INotificationService
{
  private readonly IHubContext<NotificationHub> _hubContext;

  public NotificationService(IHubContext<> hubContext)
  {
    _hubContext = hubContext;
  }

  public async Task NotifyAsync(string message)
  {
    await _hubContext.Clients.All.SendAsync("ReceiveMessage", message);
  }
}
