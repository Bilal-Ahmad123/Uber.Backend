using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildingBlocks.Messaging.Events;
using MediatR;
using RideMatching.Domain.Notifications;

namespace RideMatching.Infrastructure.NotificationHandler;
public class RiderRideRequestNotificationHandler : INotificationHandler<RiderRequestedRideNotification>
{

    public Task Handle(RiderRequestedRideNotification notification, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
