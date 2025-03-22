using Vehicle.Domain.Models.Vehicle;
using Vehicle.Domain.ValueObjects;

namespace Vehicle.Infrastructure.Configurations.Vehicle;
public class AllVehiclesConfiguration : IEntityTypeConfiguration<AllVehicleModel>
{
    public void Configure(EntityTypeBuilder<AllVehicleModel> builder)
    {
        builder.HasKey(d => d.Id);

        builder.Property(d => d.Id).HasConversion(
            vehicleId => vehicleId.Value,
            vId => VehicleId.Of(vId)
        );

        builder.Property(d => d.VehicleName)
            .HasMaxLength(100)
            .IsRequired(true);

        builder.Property(d => d.MaxSeats)
            .IsRequired(true);

        builder.Property(d => d.BaseFare)
            .IsRequired(true);

        builder.Property(d => d.RatePerKM)
            .IsRequired(true);

        builder.Property(d => d.ImageUrl)
            .IsRequired(true);
    }
}
