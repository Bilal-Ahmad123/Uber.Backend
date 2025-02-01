
using Authentication.Application.Users.Queries.GetUser;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.API.Endpoints.CheckUserExists;

public record CheckUserExistsRequest(string Email);
public record CheckUserExistsResponse(bool UserExists);
public class CheckRiderExists : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
       app.MapGet("/api/rider/exists",async ([FromQuery]string email,ISender sender) =>
       {
           var result = await sender.Send(new CheckIfRiderExistsQuery(email));
           var response = result.Adapt<CheckUserExistsResponse>();
           return Results.Ok(response);
       }).WithName("CheckRiderExists")
       .Produces<CheckUserExistsResponse>(StatusCodes.Status200OK)
       .ProducesProblem(StatusCodes.Status400BadRequest)
       .ProducesProblem(StatusCodes.Status404NotFound)
       .WithSummary("Check if Rider Exists")
       .WithDescription("Check if Rider Exists");

    }
}
