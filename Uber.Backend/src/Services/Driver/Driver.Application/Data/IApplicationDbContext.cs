using Microsoft.EntityFrameworkCore;
using DriverModel = Driver.Domain.Models.Driver.Driver;
namespace Driver.Application.Data;

public interface IApplicationDbContext
{
    DbSet<DriverModel> Drivers { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
