



namespace Authentication.API.Endpoints.CreateUser;

public record CreateUserRequest(UserDto User);
public record CreateUserResponse(Guid Id);
public class CreateUser : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/create/user",async (CreateUserRequest request,ISender sender) =>
        {
            var command = request.Adapt<>
        })
    }
}
