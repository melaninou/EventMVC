﻿// <auto-generated />
using System;
using Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infra.Migrations
{
    [DbContext(typeof(EventProjectDbContext))]
    partial class EventProjectDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Data.AttendingDbRecord", b =>
                {
                    b.Property<string>("EventID");

                    b.Property<string>("ProfileID");

                    b.HasKey("EventID", "ProfileID");

                    b.HasIndex("ProfileID");

                    b.ToTable("EventProfile");
                });

            modelBuilder.Entity("Data.EventDbRecord", b =>
                {
                    b.Property<string>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<string>("Description");

                    b.Property<string>("EventImage");

                    b.Property<string>("Location");

                    b.Property<string>("Name");

                    b.Property<string>("Organizer");

                    b.Property<int>("Type");

                    b.HasKey("ID");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("Data.ProfileDbRecord", b =>
                {
                    b.Property<string>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AboutText");

                    b.Property<DateTime>("BirthDay");

                    b.Property<int>("Gender");

                    b.Property<string>("Location");

                    b.Property<string>("Name");

                    b.Property<string>("Occupation");

                    b.Property<string>("ProfileImage");

                    b.HasKey("ID");

                    b.ToTable("Profiles");
                });

            modelBuilder.Entity("Data.AttendingDbRecord", b =>
                {
                    b.HasOne("Data.EventDbRecord", "Events")
                        .WithMany()
                        .HasForeignKey("EventID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Data.ProfileDbRecord", "Profiles")
                        .WithMany()
                        .HasForeignKey("ProfileID")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
