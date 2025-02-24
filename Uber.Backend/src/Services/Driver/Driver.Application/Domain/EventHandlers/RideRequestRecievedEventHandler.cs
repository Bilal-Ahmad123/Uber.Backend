using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildingBlocks.Events.Driver;
using MassTransit;

namespace Driver.Application.Domain.EventHandlers;
public class RideRequestRecievedEventHandler : IConsumer<RideRequestRecievedEvent>
{
    public Task Consume(ConsumeContext<RideRequestRecievedEvent> context)
    {
        throw new NotImplementedException();
    }
}
