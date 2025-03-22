using DriverVehicle = Vehicle.Domain.Models.Vehicle.Vehicle;
namespace Vehicle.Infrastructure.Configurations.Vehicle;
public class VehicleConfiguration : IEntityTypeConfiguration<DriverVehicle>
{
    public void Configure(EntityTypeBuilder<DriverVehicle> builder)
    {
        builder.HasKey(d => d.Id);
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

        builder.HasOne(d => d.AllVehicleModel)
            .WithOne()
            .HasForeignKey<DriverVehicle>(d => d.AllVehicleModelId);


    }
}
