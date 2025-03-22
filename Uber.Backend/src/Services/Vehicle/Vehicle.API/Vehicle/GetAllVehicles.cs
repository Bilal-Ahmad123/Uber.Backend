
using Vehicle.Application.Vehicle.Queries.GetVehicle;
using Vehicle.Domain.Dtos.Vehicle;

namespace Vehicle.API.Endpoints.Vehicle;

public record GetAllVehiclesResponse(IEnumerable<VehicleDto> Vehicles);
public class GetAllVehicles : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("api/vehicle/all", async (ISender sender) =>
        {
            var result = await sender.Send(new GetAllVehiclesQuery());
            var response = result.Vehicles.Adapt<GetAllVehiclesResponse>();
            return Results.Ok(result);
        }).WithName("GetAllVehicles")
        .Produces<GetAllVehiclesResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Get All Vehicles")
        .WithDescription("Get All Vehicles");
    }
}
