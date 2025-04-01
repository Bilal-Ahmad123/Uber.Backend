using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildingBlocks.Common;
using Grpc.Core;
using MassTransit.Initializers;
using Microsoft.AspNetCore.Http;
using Vehicle.Application.Repositories;

namespace Vehicle.Infrastructure.Services;
public class MyVehicleService(IVehicleRepository vehicleRepository,IHttpContextAccessor httpContextAccessor):VehicleService.VehicleServiceBase
{
    public override async Task<VehicleResponseList> GetVehicleDetails(VehicleRequest request, ServerCallContext context)
    {
        var vehicles= await vehicleRepository.GetNearbyVehicleDetails(request.DriverId.Select(d => new Guid(d)).ToList());
        var response = new VehicleResponseList();
        var baseUrl = Helper.GetVehicleUrl(httpContextAccessor.HttpContext);
        response.VehicleResponse.AddRange(vehicles.Select(v => new VehicleResponse
        {
            VehicleType = v.VehicleName,
            MaxSeats = v.MaxSeats,
            Fare = (double)v.BaseFare,
            ImageUrl = baseUrl + v.ImageUrl
        }));
        return response;
    }
}
