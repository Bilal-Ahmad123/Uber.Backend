using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rider.Domain.Models;

namespace Rider.Application.Data.Services;
public interface ISignalRService
{
    void SendDriverLocationToRiders(DriverPositionWithRiders driverPositionWithRiders);
    void NotifyRiderRideAccepted(Guid rideId);
}
