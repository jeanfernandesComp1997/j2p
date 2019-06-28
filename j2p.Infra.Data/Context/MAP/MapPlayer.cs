using j2p.Domain.Entities;
using j2p.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace j2p.Infra.Data.Context.MAP
{
    public class MapPlayer : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder.ToTable("Player");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Password).HasMaxLength(36).IsRequired();

            builder.OwnsOne<Name>(x => x.Name, cb =>
            {
                cb.Property(x => x.FirstName).HasMaxLength(50).HasColumnName("FirstName").IsRequired();
                cb.Property(x => x.LastName).HasMaxLength(50).HasColumnName("LastName").IsRequired();
            });

            builder.OwnsOne<Email>(x => x.Email, cb =>
            {
                cb.Property(x => x.Adress).HasMaxLength(200).HasColumnName("Email").IsRequired();
            });

            builder.Property(x => x.Phone).HasMaxLength(50).IsRequired();

            builder.Property(x => x.Picture).HasMaxLength(200).IsRequired();
        }
    }
}
