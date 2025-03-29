using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vehicle.Application.Data;
using Vehicle.Application.Repositories;
using Vehicle.Domain.Models.Vehicle;
using Vehicle.Domain.ValueObjects;

namespace Vehicle.Infrastructure.Repository.Vehicle;
public class AllVehiclesRepository(IApplicationDbContext dbContext) : IAllVehiclesRepository
{
    public async Task RegisterNewVehicle(AllVehicleModel vehicle, CancellationToken cancellationToken)
    {
        dbContext.AllVehicles.Add(vehicle);
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<VehicleId?> GetVehicleId(string name)
    {
        var vehicle =  await dbContext.AllVehicles.FirstOrDefaultAsync(v => v.VehicleName.Equals(name));
        if(vehicle != null)
            return vehicle.Id;
        return null;
    }
}
