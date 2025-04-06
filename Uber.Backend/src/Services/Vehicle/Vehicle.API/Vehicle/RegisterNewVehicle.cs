
using Vehicle.Application.Vehicle.Commands.RegisterNewVehicle;
using Vehicle.Domain.Dtos.Vehicle;

namespace Vehicle.API.Endpoints.Vehicle
{
    public record RegisterNewVehicleRequest(RegisterNewVehicleDto AllVehicleDto);
    public record RegisterNewVehicleResponse(Guid VehicleId);
    public class RegisterNewVehicle : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("api/register/new/vehicle", async (HttpRequest request, ISender sender) =>
            {
                var form = await request.ReadFormAsync();
                var requestCommand = new RegisterNewVehicleCommand
                (
                   form["vehicleName"].ToString(),
                   int.Parse(form["maxSeats"]!),
                   decimal.Parse(form["baseFare"]!),
                   decimal.Parse(form["ratePerKM"]!),
                   form.Files["image"]!,
                   form["vehicleDescription"].ToString()

                );
                var result = await sender.Send(requestCommand);
                var response = result.Adapt<RegisterNewVehicleResponse>();
                return Results.Ok(response);
            }).WithDescription("Register New Vehicle")
            .DisableAntiforgery()
            .Produces<RegisterNewVehicleResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithName("RegisterNewVehicle");
        }
    }
}
