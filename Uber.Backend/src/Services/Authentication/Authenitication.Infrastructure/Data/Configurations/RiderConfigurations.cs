namespace Authenitication.Infrastructure.Data.Configurations
{
    public class RiderConfigurations : IEntityTypeConfiguration<Rider>
    {
        public void Configure(EntityTypeBuilder<Rider> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasConversion(
                riderId => riderId.Value,
                dbId => UserId.Of(dbId)
            );
            builder.Property(c => c.FirstName).IsRequired();
            builder.Property(c => c.LastName).IsRequired();
            builder.Property(c => c.Email).IsRequired();
            builder.Property(c => c.ContactNumber).IsRequired();
            builder.Property(c => c.Country).IsRequired();
        }
    }
}
