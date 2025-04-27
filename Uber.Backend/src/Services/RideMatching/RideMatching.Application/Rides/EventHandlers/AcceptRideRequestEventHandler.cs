using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildingBlocks.Messaging.Events;
using Mapster;
using MassTransit;
using RideMatching.Application.Rides.Services;

namespace RideMatching.Application.Rides.EventHandlers;
public class AcceptRideRequestEventHandler(IPublishEndpoint publishEndpoint) : IConsumer<AcceptRideRequestEvent>
{
    public Task Consume(ConsumeContext<AcceptRideRequestEvent> context)
    {

        //Adavanced Scenario for future
        //redisService.LockRideRequest(context.Message.RideId, context.Message.DriverId);
        publishEndpoint.Publish(context.Message.Adapt<NotifyRiderRideAcceptedEvent>());
        return Task.CompletedTask;
    }
}
