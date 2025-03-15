using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rider.Domain.ValueObjects;
using RiderModel = Rider.Domain.Models.Rider.Rider;

namespace Rider.Infrastructure.Configurations;
public class RiderConfiguration : IEntityTypeConfiguration<RiderModel>
{
    public void Configure(EntityTypeBuilder<RiderModel> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id).HasConversion(
            riderId => riderId.Value,
            rId => RiderId.Of(rId)
        );
        builder.Property(c => c.FirstName).IsRequired();
        builder.Property(c => c.LastName).IsRequired();
        builder.Property(c => c.Country).IsRequired();
        builder.Property(c => c.ContactNumber).IsRequired();
    }
}
