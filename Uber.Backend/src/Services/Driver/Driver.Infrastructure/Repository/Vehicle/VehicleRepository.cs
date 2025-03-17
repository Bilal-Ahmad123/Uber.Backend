using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Driver.Application.Data;
using Driver.Application.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Driver.Infrastructure.Repository.Vehicle;
public class VehicleRepository(IApplicationDbContext dbContext) : IVehicleRepository
{
    public async Task<Domain.Models.Vehicle.Vehicle> GetVehicleDetails(Guid driverId)
    {
       var vehicle =  await dbContext.Vehicles.FirstOrDefaultAsync(x => x.DriverId == driverId);

        if(vehicle is null)
        {
            throw new InvalidOperationException("Vehicle not found.");
        }
        return vehicle;
    }
}
