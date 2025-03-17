using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Driver.Application.Repositories;
using Driver.Application.Vehicle.Queries.GetVehicle;
using Mapster;
using MediatR;

namespace Driver.Application.Vehicle.Queries.GetVehicleDetails;
public class GetVehicleDetailsHandler(IVehicleRepository vehicleRepository) : IQueryHandler<GetVehicleDetailsQuery, GetVehicleDetailsResult>
{
    public Task<GetVehicleDetailsResult> Handle(GetVehicleDetailsQuery request, CancellationToken cancellationToken)
    {
        var vehicle = vehicleRepository.GetVehicleDetails(request.DriverId);
        return Task.FromResult(vehicle.Result.Adapt<GetVehicleDetailsResult>());
    }
}
