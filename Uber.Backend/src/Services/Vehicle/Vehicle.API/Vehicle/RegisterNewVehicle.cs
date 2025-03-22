
using Vehicle.Application.Vehicle.Commands.RegisterNewVehicle;
using Vehicle.Domain.Dtos.Vehicle;

namespace Vehicle.API.Endpoints.Vehicle
{
    public record RegisterNewVehicleRequest(AllVehicleDto AllVehicleDto);
    public record RegisterNewVehicleResponse(Guid VehicleId);
    public class RegisterNewVehicle : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("api/register/new/vehicle",async ([FromBody] RegisterNewVehicleRequest command, ISender sender) =>
            {
                var request = command.Adapt<RegisterNewVehicleCommand>();
                var result = await sender.Send(request);
                var response = result.Adapt<RegisterNewVehicleResponse>();
                return Results.Ok(response);
            }).WithDescription("Register New Vehicle")
            .Produces<RegisterNewVehicleResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithName("RegisterNewVehicle");
        }
    }
}
