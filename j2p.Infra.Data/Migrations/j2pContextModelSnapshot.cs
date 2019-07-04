﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using j2p.Infra.Data.Context;

namespace j2p.Infra.Data.Migrations
{
    [DbContext(typeof(j2pContext))]
    partial class j2pContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("j2p.Domain.Entities.Event", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<Guid?>("IdOrganizer");

                    b.Property<int>("Limit");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(36);

                    b.Property<double>("Value");

                    b.HasKey("Id");

                    b.HasIndex("IdOrganizer");

                    b.ToTable("Event");
                });

            modelBuilder.Entity("j2p.Domain.Entities.Player", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<Guid?>("EventId");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(36);

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Picture")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.ToTable("Player");
                });

            modelBuilder.Entity("j2p.Domain.Entities.Event", b =>
                {
                    b.HasOne("j2p.Domain.Entities.Player", "Organizer")
                        .WithMany()
                        .HasForeignKey("IdOrganizer");
                });

            modelBuilder.Entity("j2p.Domain.Entities.Player", b =>
                {
                    b.HasOne("j2p.Domain.Entities.Event")
                        .WithMany("Players")
                        .HasForeignKey("EventId");
                });
#pragma warning restore 612, 618
        }
    }
}
