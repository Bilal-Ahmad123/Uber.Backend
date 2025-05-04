using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildingBlocks.Messaging.Events;
using MassTransit;

namespace Rider.Application.Rider.EventHandlers
{
    class DriverReachedPickUpSpotEventHandler : IConsumer<ReachedPickUpSpotEvent>
    {
        public Task Consume(ConsumeContext<ReachedPickUpSpotEvent> context)
        {
            throw new NotImplementedException();
        }
    }
}
