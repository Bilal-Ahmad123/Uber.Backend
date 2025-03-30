using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Vehicle.Application.Data;
using Vehicle.Application.Repositories;
using Vehicle.Domain.Models.Vehicle;
using Vehicle.Domain.ValueObjects;

namespace Vehicle.Infrastructure.Repository.Vehicle;
public class AllVehiclesRepository(IApplicationDbContext dbContext,ILogger<AllVehiclesRepository> logger) : IAllVehiclesRepository
{
    public async Task RegisterNewVehicle(AllVehicleModel vehicle, CancellationToken cancellationToken)
    {
        dbContext.AllVehicles.Add(vehicle);
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<VehicleId?> GetVehicleId(string name)
    {
        try
        {
            var vehicle = await dbContext.AllVehicles.Where(x => x.VehicleName.Equals(name)).FirstOrDefaultAsync();
            if (vehicle != null)
                return vehicle.Id;
            return null;
        }
        catch(Exception e)
        {
            logger.LogError(e.Message);
        }
        return null;
    }
}
