using Microsoft.EntityFrameworkCore;
namespace Driver.Application.Data;
using Driver.Domain.Models.Vehicle;

public interface IApplicationDbContext
{
    DbSet<Vehicle> Vehicles { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
