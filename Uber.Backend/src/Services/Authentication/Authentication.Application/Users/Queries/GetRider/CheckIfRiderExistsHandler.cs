using Authentication.Application.Data;
using BuildingBlocks.CQRS;

namespace Authentication.Application.Users.Queries.GetUser;
public class CheckIfRiderExistsHandler(IApplicationDbContext dbContext) : IQueryHandler<CheckIfRiderExistsQuery, CheckIfUserExistsResult>
{
    public async Task<CheckIfUserExistsResult> Handle(CheckIfRiderExistsQuery request, CancellationToken cancellationToken)
    {
        var user = await dbContext.Users.FirstOrDefaultAsync(u => u.Email.Equals(request.Email));
        if (user is not null)
        {
            return new CheckIfUserExistsResult(user.Id.Value);
        }
        return new CheckIfUserExistsResult(Guid.Empty);
    }
}
