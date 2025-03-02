using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildingBlocks.Messaging.Events;
using Driver.Application.Services;
using Driver.Domain.Models.RiderLocation;
using Mapster;
using MassTransit;

namespace Driver.Infrastructure.Consumers.RideRequest;
public class RideRequest(ISignalRService signalRService) : IConsumer<DriverRideRequestEvent>
{
    public Task Consume(ConsumeContext<DriverRideRequestEvent> context)
    {
        signalRService.SendRideRequestToDriver(context.Message.Adapt<RiderRequestedLocation>());
        return Task.CompletedTask;
    }
}
