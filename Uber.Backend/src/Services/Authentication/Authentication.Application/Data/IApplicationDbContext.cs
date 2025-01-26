
namespace Authentication.Application.Data;
public interface IApplicationDbContext
{
    DbSet<Rider> Riders { get; }
    DbSet<Driver> Drivers { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
