using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleModel = Driver.Domain.Models.Vehicle.Vehicle;

namespace Driver.Application.Repositories;
public interface IVehicleRepository
{
    Task<VehicleModel> GetVehicleDetails(Guid driverId);
}
