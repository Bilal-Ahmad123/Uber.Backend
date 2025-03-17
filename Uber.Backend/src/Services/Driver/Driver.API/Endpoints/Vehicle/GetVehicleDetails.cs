﻿using Carter;
using Driver.Application.Vehicle.Queries.GetVehicleDetails;
using Mapster;
using MediatR;

namespace Driver.API.Endpoints.Vehicle
{
    public record GetVehicleDetailsResponse(
        string VehicleMake,
        string VehicleModel,
        string VehicleYear,
        string VehicleColor,
        string VehiclePlateNumber,
        string VehicleType
    );
    public class GetVehicleDetails : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("api/vehicle/details", async([FromQuery] Guid driverId,ISender sender) =>
            {
                var result = await sender.Send(new GetVehicleDetailsQuery(driverId));
                var response = result.Adapt<GetAllVehiclesResponse>();
                return Results.Ok(response);
            }).WithName("GetVehicleDetails")
            .Produces<GetVehicleDetailsResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("Get Vehicle Details")
            .WithDescription("Get Vehicle Details");
        }
    }
}
