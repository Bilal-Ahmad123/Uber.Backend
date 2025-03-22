using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Rider.API.Endpoints.Ride;

public class GetNearbyVehicles : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("api/ride/nearby/vehicle", async ([FromQuery] Guid riderId ,ISender sender) =>
        {

        })
    }
}
