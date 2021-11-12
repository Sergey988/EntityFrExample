using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrExample_FluentAPI_
{
    internal class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.Property(c => c.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(e => e.Email)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.Property(g => g.Gender)
                   .IsRequired()
                   .HasMaxLength(20);
            
       //     builder.HasOne(f => f.Flight)
       //.WithMany(c => c.Cliets)
       //.HasForeignKey(fi => fi.FlightNumber);
        }
    }
}
