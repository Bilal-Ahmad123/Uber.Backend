using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildingBlocks.Messaging.Events;
using MassTransit;
using Rider.Application.Data.Services;

namespace Rider.Application.Rider.EventHandlers;
public class NotifyRiderRideAccpetedEventHandler(ISignalRService signalRService) : IConsumer<NotifyRiderRideAcceptedEvent>
{
    public Task Consume(ConsumeContext<NotifyRiderRideAcceptedEvent> context)
    {
        signalRService.NotifyRiderRideAccepted(context.Message.RiderId);
        return Task.CompletedTask;
    }
}
