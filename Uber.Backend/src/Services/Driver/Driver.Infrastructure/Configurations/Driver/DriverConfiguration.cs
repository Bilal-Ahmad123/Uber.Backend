using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using DriverModel = Driver.Domain.Models.Driver.Driver;
using Driver.Domain.ValueObjects;

namespace Driver.Infrastructure.Configurations.Driver;
public class DriverConfiguration : IEntityTypeConfiguration<DriverModel>
{
    public void Configure(EntityTypeBuilder<DriverModel> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id).HasConversion(
            driverId => driverId.Value,
            dId => DriverId.Of(dId)
            );
    }
}
