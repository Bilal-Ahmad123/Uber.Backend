using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle.Domain.Models.Vehicle;
using Vehicle.Domain.ValueObjects;

namespace Vehicle.Application.Repositories;
public interface IAllVehiclesRepository
{
    public Task RegisterNewVehicle(AllVehicleModel vehicle, CancellationToken cancellationToken);
    public  Task<VehicleId?> GetVehicleId(string name);
}
