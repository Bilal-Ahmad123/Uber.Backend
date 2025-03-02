using BuildingBlocks.Messaging.Events;
using Mapster;
using MassTransit;
using MediatR;
using RideMatching.Application.Rides.Services;

namespace RideMatching.Application.Rides.EventHandlers
{
    public class RiderRideRequestEventHandler(IPublishEndpoint publishEndpoint,IMediator mediator) : IConsumer<RequestRideEvent>
    {
        public async Task Consume(ConsumeContext<RequestRideEvent> context)
        {
           await mediator.Publish(context.Message.Adapt<>)
            redisService.StoreRideRequest(context.Message);
            IList<Guid> nearbyDrivers = await redisService.FindNearbyDrivers(context.Message.RiderId);
            await publishEndpoint.Publish(MapDriverRideRequestEvent(context.Message,nearbyDrivers));
        }

        private DriverRideRequestEvent MapDriverRideRequestEvent(RequestRideEvent requestRide , IList<Guid> nearbyDrivers)
        {
            return new DriverRideRequestEvent
            (
               requestRide.RideId,
               requestRide.RiderId,
               requestRide.PickUpLocation,
               requestRide.DropOffLocation,
               nearbyDrivers
            );
        }
    }
}
