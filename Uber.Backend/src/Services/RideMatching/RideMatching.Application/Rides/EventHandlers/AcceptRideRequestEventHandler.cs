using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildingBlocks.Messaging.Events;
using MassTransit;
using RideMatching.Application.Rides.Services;

namespace RideMatching.Application.Rides.EventHandlers;
public class AcceptRideRequestEventHandler(IRedisService redisService,IPublishEndpoint publishEndpoint) : IConsumer<AcceptRideRequestEvent>
{
    public Task Consume(ConsumeContext<AcceptRideRequestEvent> context)
    {
        redisService.LockRideRequest(context.Message.RideId, context.Message.DriverId);
        Guid riderId = redisService.GetRiderId(context.Message.RideId);
        publishEndpoint.Publish(new NotifyRiderRideAcceptedEvent(riderId,context.Message.DriverId));
        return Task.CompletedTask;
    }
}
