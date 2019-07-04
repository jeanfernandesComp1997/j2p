using j2p.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace j2p.Infra.Data.Context.MAP
{
    public class MapEvent : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.ToTable("Event");

            builder.HasOne(x => x.Organizer).WithMany().HasForeignKey("IdOrganizer");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title).HasMaxLength(36).IsRequired();

            builder.Property(x => x.Date).IsRequired();

            builder.Property(x => x.Value);

            builder.Property(x => x.Limit).IsRequired();

            builder.Property(x => x.Status).HasMaxLength(50).IsRequired();
        }
    }
}
