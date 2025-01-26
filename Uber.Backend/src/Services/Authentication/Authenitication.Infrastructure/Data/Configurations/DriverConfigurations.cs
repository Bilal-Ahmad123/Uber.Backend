namespace Authenitication.Infrastructure.Data.Configurations;
public class DriverConfigurations : IEntityTypeConfiguration<Driver>
{
    public void Configure(EntityTypeBuilder<Driver> builder)
    {
        builder.HasKey(d => d.Id);

        builder.Property(c => c.Id).HasConversion(
              driverId => driverId.Value,
              dbId => UserId.Of(dbId)
          );

        builder.Property(d => d.FirstName)
               .HasMaxLength(50) 
               .IsRequired();    

        builder.Property(d => d.LastName)
               .HasMaxLength(50) 
               .IsRequired();    

        builder.Property(d => d.Email)
               .HasMaxLength(255)
               .IsRequired();    
        builder.HasIndex(d => d.Email).IsUnique();

        builder.Property(d => d.ContactNumber)
               .HasMaxLength(15)
               .IsRequired();    

        builder.Property(d => d.Country)
               .HasMaxLength(50) 
               .IsRequired();   

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
