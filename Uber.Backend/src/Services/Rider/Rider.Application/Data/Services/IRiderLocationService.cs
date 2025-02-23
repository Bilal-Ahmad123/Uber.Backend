using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildingBlocks.Events;

namespace Rider.Application.Data.Services;
public interface IRiderLocationService
{
    void SendRiderLocationUpdate(UpdateUserLocation driverLocation);
    void GetDriverLocationUpdate();
}
