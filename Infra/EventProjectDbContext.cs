﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Data;
using Microsoft.EntityFrameworkCore;

namespace Infra
{
    public class EventProjectDbContext : DbContext
    {
        public EventProjectDbContext(DbContextOptions<EventProjectDbContext> o) : base(o) { }

        public DbSet<ProfileDbRecord> Profiles { get; set; }

        public DbSet<EventDbRecord> Events { get; set; }

        public DbSet<EventProfileDbRecord> EventsProfiles { get; set; }

        protected override void OnModelCreating(ModelBuilder b)
        {
            base.OnModelCreating(b);
            b.Entity<ProfileDbRecord>().ToTable("Profiles");
            b.Entity<EventDbRecord>().ToTable("Events");
            createProfilesTable(b);
            createEventsTable(b);
            createEventProfileTable(b);
        }

        internal static void createEventsTable(ModelBuilder b)
        {
            const string table = "Events";
            b.Entity<EventDbRecord>().ToTable(table);
        }

        internal static void createProfilesTable(ModelBuilder b)
        {
            const string table = "Profiles";
            b.Entity<ProfileDbRecord>().ToTable(table);
        }

        internal static void createEventProfileTable(ModelBuilder b)
        {
            const string table = "EventProfile";
            createPrimaryKey<EventProfileDbRecord>(b, table, a => new {a.EventID, a.ProfileID});
            createForeignKey<EventProfileDbRecord, EventDbRecord>(b, table, x => x.EventID, x => x.Events);
            createForeignKey< EventProfileDbRecord, ProfileDbRecord>(b, table, x => x.ProfileID, x => x.Profiles);
        }
        internal static void createPrimaryKey<TEntity>(ModelBuilder b, string tableName,
            Expression<Func<TEntity, object>> primaryKey) where TEntity : class
        {
            b.Entity<TEntity>()
                .ToTable(tableName)
                .HasKey(primaryKey);
        }

        internal static void createForeignKey<TEntity, TRelatedEntity>(ModelBuilder b, string tableName,
            Expression<Func<TEntity, object>> foreignKey,
            Expression<Func<TEntity, TRelatedEntity>> getRelatedEntity)
            where TEntity : class where TRelatedEntity : class
        {
            b.Entity<TEntity>()
                .ToTable(tableName)
                .HasOne(getRelatedEntity)
                .WithMany()
                .HasForeignKey(foreignKey)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}