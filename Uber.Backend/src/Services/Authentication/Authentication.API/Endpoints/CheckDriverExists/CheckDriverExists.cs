

using Authentication.Application.Users.Queries.GetDriver;

namespace Authentication.API.Endpoints.CheckDriverExists;

public record CheckDriverExistsResponse(bool DriverExists);
public class CheckDriverExists:ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("api/driver/exists", async([FromQuery] string email,ISender sender) =>
        {
            var result = await sender.Send(new CheckDriverExistsQuery(email));
            var response = result.Adapt<CheckDriverExistsResponse>();
            return Results.Ok(response);
        }).
        WithName("CheckDriverExists")
        .Produces<CheckDriverExistsResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Check if Driver Exists")
        .WithDescription("Check if Driver Exists");
    }

}
