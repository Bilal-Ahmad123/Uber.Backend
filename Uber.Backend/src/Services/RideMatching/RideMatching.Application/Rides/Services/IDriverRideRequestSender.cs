using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideMatching.Application.Rides.Services;
public interface IDriverRideRequestSender
{
    public Task SendRideRequestToNearbyDrivers();
}
