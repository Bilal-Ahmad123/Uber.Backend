using BuildingBlocks.Messaging.Events;
using MassTransit;
using Rider.Application.Data.Services;
using Rider.Domain.Models;

namespace Rider.Infrastructure.Services;
public class Ride(IPublishEndpoint publishEndpoint) : IRide
{
    public async Task RequestRide(RequestRideEvent requestRide)
    {
        await publishEndpoint.Publish(requestRide);
    }
}
