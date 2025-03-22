﻿
using VehicleModel = Vehicle.Domain.Models.Vehicle.Vehicle;

namespace Vehicle.Application.Repositories;
public interface IVehicleRepository
{
    Task<VehicleModel> GetVehicleDetails(Guid driverId);
}
