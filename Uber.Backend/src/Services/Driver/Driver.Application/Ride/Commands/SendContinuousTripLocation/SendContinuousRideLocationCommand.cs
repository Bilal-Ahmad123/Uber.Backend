using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildingBlocks.Models.Ride;
using MediatR;

namespace Driver.Application.Ride.Commands.SendContinuousTripLocation
{
    public record SendContinuousRideLocationCommand(ContinuousTripUpdates trip):ICommand<Unit>;
}
