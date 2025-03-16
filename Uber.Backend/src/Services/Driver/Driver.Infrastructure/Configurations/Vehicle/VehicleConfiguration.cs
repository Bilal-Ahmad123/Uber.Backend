using Driver.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DriverVehicle = Driver.Domain.Models.Vehicle.Vehicle;
namespace Driver.Infrastructure.Configurations.Vehicle;
public class VehicleConfiguration : IEntityTypeConfiguration<DriverVehicle>
{
    public void Configure(EntityTypeBuilder<DriverVehicle> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(d => d.Id).HasConversion(
            vehicleId => vehicleId.Value,
            vId => VehicleId.Of(vId)
            );

        builder.Property(d => d.VehicleType)
               .HasMaxLength(50)
               .IsRequired(true);

        builder.Property(d => d.VehicleModel)
               .HasMaxLength(50)
               .IsRequired(true);

        builder.Property(d => d.VehiclePlateNumber)
               .HasMaxLength(20)
               .IsRequired(true);

        builder.Property(d => d.VehicleColor)
               .HasMaxLength(30)
               .IsRequired(true);

        builder.Property(d => d.VehicleYear)
               .HasMaxLength(4)
               .IsRequired(true);

        builder.Property(d => d.VehicleMake)
               .HasMaxLength(50)
               .IsRequired(true);

        builder.Property(d => d.DriverId)
            .IsRequired(true);
    }
}
