using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildingBlocks.CQRS;
using MediatR;
using Microsoft.Extensions.Logging;
using Rider.Application.Data.Services;
using RiderLocation = BuildingBlocks.Events.UpdateUserLocation;

namespace Rider.Application.Rider.Commands.UpdateRiderLocation;
public class UpdateRiderLocationCommandHandler(ILogger<UpdateRiderLocationCommandHandler> logger, IRiderLocationService repository) : ICommandHandler<UpdateRiderLocationCommand, Unit>
{
    public Task<Unit> Handle(UpdateRiderLocationCommand request, CancellationToken cancellationToken)
    {
        var eventMessage = new RiderLocation
       (
          request.LocationDto.UserId,
          request.LocationDto.Latitude,
          request.LocationDto.Longitude
       );
        logger.LogInformation("Rider Location Recieved");
        repository.SendRiderLocationUpdate(eventMessage);
        return Task.FromResult(Unit.Value);
    }
}
