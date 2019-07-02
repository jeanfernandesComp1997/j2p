using j2p.Domain.Entities;
using j2p.Infra.Data.Context.MAP;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;

namespace j2p.Infra.Data.Context
{
    public class j2pContext : DbContext
    {
        public j2pContext(DbContextOptions<j2pContext> options)
        : base(options)
        { }

        public DbSet<Player> Player { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //app settings
            modelBuilder.ApplyConfiguration(new MapPlayer());

            base.OnModelCreating(modelBuilder);
        }

        public virtual int SaveChanges(IEnumerable<EntityEntry> entries)
        {
            return base.SaveChanges();
        }
    }
}
