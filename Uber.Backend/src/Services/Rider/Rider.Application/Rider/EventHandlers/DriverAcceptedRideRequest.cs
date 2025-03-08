using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildingBlocks.Messaging.Events;
using MassTransit;

namespace Rider.Application.Rider.EventHandlers;
internal class DriverAcceptedRideRequest : IConsumer<DriverAcceptedRide>
{
    public Task Consume(ConsumeContext<DriverAcceptedRide> context)
    {
        throw new NotImplementedException();
    }
}
