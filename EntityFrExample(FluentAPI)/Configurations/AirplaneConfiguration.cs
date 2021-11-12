using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;



namespace EntityFrExample_FluentAPI_
{
    internal class AirplaneConfiguration : IEntityTypeConfiguration<Airplane>
    {
        public void Configure(EntityTypeBuilder<Airplane> builder)
        {
            builder.Property(m => m.Model)
                   .IsRequired()
                   .HasMaxLength(500);

            builder.Property(t => t.Type)
                   .IsRequired()
                   .HasMaxLength(50);
        }
    }
}
