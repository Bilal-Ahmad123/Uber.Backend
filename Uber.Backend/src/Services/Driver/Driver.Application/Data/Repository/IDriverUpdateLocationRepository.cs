using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildingBlocks.Events;
using BuildingBlocks.Models.Driver;

namespace Driver.Application.Data.Repository;
public interface IDriverUpdateLocationRepository
{
    void SendDriverLocationUpdate(UpdateDriverLocation driverLocation);
    void GetDriverLocationUpdate();
}
