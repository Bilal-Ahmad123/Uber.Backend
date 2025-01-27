using Authentication.Application.Users.Commands.CreateUser.CreateRider;

namespace Authentication.API.Endpoints.CreateUser;

public record CreateRiderRequest(RiderDto Rider);
public record CreateRiderResponse(Guid Id);
public class CreateRider : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/create/rider", async (CreateRiderRequest request, ISender sender) =>
        {
            var command = request.Adapt<CreateRiderCommand>();
            var result = await sender.Send(command);
            var response = result.Adapt<CreateRiderResponse>();
            return Results.Ok(response);
        })
         .WithName("CreateRider")
        .Produces<CreateRiderResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Create Rider")
        .WithDescription("Create Rider");
    }
}
