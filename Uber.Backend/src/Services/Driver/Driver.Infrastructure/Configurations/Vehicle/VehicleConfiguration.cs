using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Driver.Infrastructure.Configurations.Vehicle;
using DriverVehicle = Driver.Domain.Models.Vehicle.Vehicle;
public class VehicleConfiguration : IEntityTypeConfiguration<DriverVehicle>
{
    public void Configure(EntityTypeBuilder<DriverVehicle> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(d => d.VehicleType)
               .HasMaxLength(50)
               .IsRequired(false);

        builder.Property(d => d.VehicleModel)
               .HasMaxLength(50)
               .IsRequired(false);

        builder.Property(d => d.VehiclePlateNumber)
               .HasMaxLength(20)
               .IsRequired(false);

        builder.Property(d => d.VehicleColor)
               .HasMaxLength(30)
               .IsRequired(false);

        builder.Property(d => d.VehicleYear)
               .HasMaxLength(4)
               .IsRequired(false);

        builder.Property(d => d.VehicleMake)
               .HasMaxLength(50)
               .IsRequired(false);
    }
}
