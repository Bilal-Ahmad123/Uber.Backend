using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Driver.Application.Ride.Commands.SendContinuousTripLocation
{
    public record SendContinuousRideLocationCommand(Guid RideId, Guid DriverId, double Longitude, double Latitude, Guid RiderId):ICommand<Unit>;
}
