using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildingBlocks.Messaging.Events;
using MassTransit;

namespace RideMatching.Application.Rides.EventHandlers;
public class AcceptRideRequestEventHandler : IConsumer<AcceptRideRequestEvent>
{
    public Task Consume(ConsumeContext<AcceptRideRequestEvent> context)
    {
        throw new NotImplementedException();
    }
}
