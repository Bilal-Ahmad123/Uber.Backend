using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildingBlocks.Messaging.Events;
using Driver.Application.Services;
using Mapster;
using MassTransit;
using MediatR;

namespace Driver.Application.Ride.Commands.SendContinuousTripLocation;
internal class SendContinuousRideLocationCommandHandler(IDriverRedisService driverRedisService) : ICommandHandler<SendContinuousRideLocationCommand, Unit>
{
    public Task<Unit> Handle(SendContinuousRideLocationCommand request, CancellationToken cancellationToken)
    {
        driverRedisService.SendTripLocationUpdates(request.trip);
        return Task.FromResult(Unit.Value);
    }
}
