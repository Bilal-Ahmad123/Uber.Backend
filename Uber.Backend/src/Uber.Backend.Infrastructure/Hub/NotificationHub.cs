using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uber.Backend.Core;

namespace Uber.Backend.Infrastructure.Hub;
public class NotificationHub : INotificationService
{
  public readonly INotificationService _notificationService;

  public NotificationHub(INotificationService notificationService)
  {
    _notificationService = notificationService;
  }

  public async Task NotifyAsync(string message)
  {
     await _notificationService.NotifyAsync("Hello There");
  }
}
