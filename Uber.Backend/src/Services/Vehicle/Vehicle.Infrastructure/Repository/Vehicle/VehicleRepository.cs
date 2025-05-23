﻿using System.Threading;
using Microsoft.Extensions.Logging;
using Vehicle.Application.Data;
using Vehicle.Application.Repositories;
using Vehicle.Application.Services;
using Vehicle.Application.Vehicle.Commands.RegisterNewVehicle;
using Vehicle.Domain.Dtos.Vehicle;
using Vehicle.Domain.Models.Vehicle;
using DriverVehicle = Vehicle.Domain.Models.Vehicle.Vehicle;
namespace Vehicle.Infrastructure.Repository.Vehicle;
public class VehicleRepository(IApplicationDbContext dbContext,IAllVehiclesRepository allVehiclesRepository,ILogger<VehicleRepository> logger) : IVehicleRepository
{
    public async Task<DriverVehicle> GetVehicleDetails(Guid driverId)
    {
       var vehicle =  await dbContext.Vehicles.FirstOrDefaultAsync(x => x.DriverId == driverId);

        if(vehicle is null)
        {
            throw new InvalidOperationException("Vehicle not found.");
        }
        return vehicle;
    }

    public Task<List<AllVehicleDto>> GetNearbyVehicleDetails(IList<Guid> driverIds)
    {
        return dbContext.Vehicles.Where(v => driverIds.Contains(v.DriverId))
            .Include(v => v.AllVehicleModel)
            .Select(v => new AllVehicleDto
            (
                v.AllVehicleModel.VehicleName, 
                v.AllVehicleModel.MaxSeats,
                v.AllVehicleModel.BaseFare,
                v.AllVehicleModel.RatePerKM,
                v.AllVehicleModel.ImageUrl,
                v.DriverId,
                v.AllVehicleModel.VehicleDescription
            )).ToListAsync();

    }

    public async Task  CreateDriverVehicle(DriverVehicle vehicle,CancellationToken cancellationToken)
    {
        try
        {
            var vehicleId = await allVehiclesRepository.GetVehicleId(vehicle.VehicleType);
            vehicle.AllVehicleModelId = vehicleId!;
            dbContext.Vehicles.Add(vehicle);
            await dbContext.SaveChangesAsync(cancellationToken);
        }catch(Exception e)
        {
            logger.LogError(e.Message);
        }
    }
}
