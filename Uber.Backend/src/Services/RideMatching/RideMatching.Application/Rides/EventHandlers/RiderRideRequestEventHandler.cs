using BuildingBlocks.Messaging.Events;
using BuildingBlocks.Models.Driver;
using Mapster;
using MassTransit;
using MediatR;
using RideMatching.Application.Rides.Services;

namespace RideMatching.Application.Rides.EventHandlers
{
    public class RiderRideRequestEventHandler(IPublishEndpoint publishEndpoint,IRedisProtoClientService redisProtoClientService) : IConsumer<RequestRideEvent>
    {
        public async Task Consume(ConsumeContext<RequestRideEvent> context)
        {
            NearbyDriverResponse nearbyDrivers = redisProtoClientService.GetNearbyDrivers(new BuildingBlocks.Events.UpdateUserLocation(context.Message.RiderId, context.Message.PickUpLocation!.Latitude, context.Message.PickUpLocation.Longitude));
            await publishEndpoint.Publish(MapDriverRideRequestEvent(context.Message,nearbyDrivers.DriverIds));
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
