namespace Authenitication.Infrastructure.Data.Configurations;
public class DriverConfigurations : IEntityTypeConfiguration<Driver>
{
    public void Configure(EntityTypeBuilder<Driver> builder)
    {
        builder.HasKey(d => d.Id);

        builder.Property(c => c.Id).HasConversion(
              driverId => driverId.Value,
              dbId => DriverId.of(dbId)
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
    }
}
