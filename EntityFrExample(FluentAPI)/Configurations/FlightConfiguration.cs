using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrExample_FluentAPI_
{
    internal class FlightConfiguration : IEntityTypeConfiguration<Flight>
    {
        public void Configure(EntityTypeBuilder<Flight> builder)
        {
            builder.Property(dc => dc.DepartureCity)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(ac => ac.ArrivalCity)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.HasOne(a => a.Airplane)
                   .WithOne(f => f.Flight)
                   .HasForeignKey<Flight>(fi => fi.AirplaneId);

            builder.HasMany(c => c.Cliets)
                   .WithOne(f => f.Flight)
                   .HasForeignKey(fi => fi.FlightNumber);
        }
    }
}
