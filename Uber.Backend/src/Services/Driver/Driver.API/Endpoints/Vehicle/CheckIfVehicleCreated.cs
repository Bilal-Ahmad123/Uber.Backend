using Carter;
using Driver.Application.Vehicle.Queries.CheckVehicle;
using Mapster;
using MediatR;

namespace Driver.API.Endpoints.Vehicle;

public record CheckVehicleCreatedResponse(bool Exists);
public class CheckIfVehicleCreated : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("api/vehicle/exists",async([FromQuery] Guid driverId, ISender sender) =>
        {
            var result = await sender.Send(new CheckVehicleCreatedQuery(driverId));
            var response = result.Adapt<CheckVehicleCreatedResponse>();
            return Results.Ok(response);
        }).WithDisplayName("CheckIfVehicleCreated")
        .Produces<CheckVehicleCreatedResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Check If Vehicle Created")
        .WithDescription("Check If Vehicle Created");
    }
}
