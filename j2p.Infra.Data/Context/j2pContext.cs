using j2p.Domain.Entities;
using j2p.Domain.ValueObjects;
using j2p.Infra.Data.Context.MAP;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using prmToolkit.NotificationPattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace j2p.Infra.Data.Context
{
    public class j2pContext : DbContext
    {
        public j2pContext(DbContextOptions<j2pContext> options)
        : base(options)
        { }

        public DbSet<Player> Players { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //ignore classes
            modelBuilder.Ignore<Notification>();
            modelBuilder.Ignore<Name>();
            modelBuilder.Ignore<Email>();

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
