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
        public DbSet<Event> Event { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //ignore classes
            modelBuilder.Ignore<User>();
            modelBuilder.Ignore<Local>();
            modelBuilder.Ignore<Owner>();

            //app settings
            modelBuilder.ApplyConfiguration(new MapPlayer());
            modelBuilder.ApplyConfiguration(new MapEvent());

            base.OnModelCreating(modelBuilder);
        }

        public virtual int SaveChanges(IEnumerable<EntityEntry> entries)
        {
            return base.SaveChanges();
        }
    }
}
