﻿using Carter;
using Driver.Application.Dtos.Vehicle;
using Driver.Application.Vehicle.Commands.CreateVehicle;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Driver.API.Endpoints.Vehicle;

public record CreateVehicleRequest(VehicleDto Vehicle);
public record CreateVehicleResponse(Guid Id);
public class CreateVehicle : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("api/vehicle/create",async ([FromBody]CreateVehicleRequest command, ISender sender) =>
        {
            var request = command.Adapt<CreateVehicleCommand>();
            var result = await sender.Send(request);
            var response = result.Adapt<CreateVehicleResponse>();
            return Results.Ok(response);
        }).WithName("CreateVehicle")
        .Produces<CreateVehicleResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Create Vehicle")
        .WithDescription("Create Vehicle");
    }
}
