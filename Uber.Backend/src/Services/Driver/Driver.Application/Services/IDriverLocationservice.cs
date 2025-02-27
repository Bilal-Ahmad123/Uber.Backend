using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildingBlocks.Events;

namespace Driver.Application.Services
{
    public interface IDriverLocationService
    {
        void SendDriverLocationUpdate(UpdateUserLocation driverLocation);
        void GetDriverLocationUpdate();
    }
}
