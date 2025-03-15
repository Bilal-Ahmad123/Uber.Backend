using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RiderModel = Rider.Domain.Models.Rider.Rider;

namespace Rider.Application.Data;
public interface IApplicationDbContext
{
    DbSet<RiderModel> Riders { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
