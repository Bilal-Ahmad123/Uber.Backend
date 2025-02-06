
using Authentication.Application.Users.Commands.CreateUser.CreateDriver;

namespace Authentication.API.Endpoints.CreateDriver;

public record CreateDriverRequest(DriverDto Driver);
public record CreateDriverResposne(Guid Id);
public class CreateDriver : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
       app.MapPost("/api/driver/create", async (CreateDriverRequest command, ISender sender) =>
       {
           var request = command.Adapt<CreateDriverCommand>();
           var result = await sender.Send(request);
           var response = result.Adapt<CreateDriverResposne>();
           return Results.Ok(response);
       })
            .WithName("CreateDriver")
            .Produces<CreateDriverResposne>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("Create Driver")
            .WithDescription("Create Driver");
    }
}
