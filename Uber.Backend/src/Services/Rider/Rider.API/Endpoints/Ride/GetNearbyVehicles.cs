using Carter;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Rider.Application.Rider.Queries.GetNearbyRides;
using Rider.Domain.Models.Vehicle;

namespace Rider.API.Endpoints.Ride;
public record GetNearbyRideQueryResponse(IList<NearbyVehicleDetails> NearbyVehicles);
public class GetNearbyVehicles : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("api/ride/nearby/vehicle", async ([FromQuery] Guid riderId, double latitude, double longitude, ISender sender) =>
        {
            var result = await sender.Send(new GetNearbyRideQuery(riderId, latitude, longitude));
            var response = result.Adapt<GetNearbyRideQueryResponse>();
            return Results.Ok(response);
        }).WithName("GetNearbyVehicles")
        .Produces<GetNearbyRideQueryResponse>(200)
        .Produces(404);
    }
}
