using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrExample_FluentAPI_
{
     class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasKey(c => c.ClientId);

            builder.Property(l => l.Login)
                   .IsRequired()
                   .HasMaxLength(20);

            builder.Property(p => p.Password)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.HasOne<Client>(c => c.Client)
                   .WithOne(a => a.Account)
                   .HasForeignKey<Account>(a => a.ClientId);
        }
    }
}
