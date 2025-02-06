

namespace Authentication.Application.Users.Queries.GetDriver;
public class CheckDriverExistsHandler(IApplicationDbContext dbContext) : IQueryHandler<CheckDriverExistsQuery, CheckDriverExistsResult>
{
    public async Task<CheckDriverExistsResult> Handle(CheckDriverExistsQuery query, CancellationToken cancellationToken)
    {
        var driver = await dbContext.Drivers.FirstOrDefaultAsync(x => x.Email.Equals(query.Email));
        if (driver is not null)
        {
            return new CheckDriverExistsResult(true);
        }
        return new CheckDriverExistsResult(false);

    }
}
