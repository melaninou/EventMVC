using System;
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

        protected override void OnModelCreating(ModelBuilder b)
        {
            base.OnModelCreating(b);
            b.Entity<ProfileDbRecord>().ToTable("Profiles");
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
