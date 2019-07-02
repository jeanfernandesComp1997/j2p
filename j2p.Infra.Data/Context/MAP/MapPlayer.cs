using j2p.Domain.Entities;
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

            builder.Property(x => x.FirstName).HasMaxLength(50).IsRequired();

            builder.Property(x => x.LastName).HasMaxLength(50).IsRequired();

            builder.Property(x => x.Email).HasMaxLength(200).IsRequired();

            builder.Property(x => x.Phone).HasMaxLength(50).IsRequired();

            builder.Property(x => x.Picture).HasMaxLength(200).IsRequired();
        }
    }
}
