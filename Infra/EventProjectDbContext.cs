using System;
using System.Linq.Expressions;
using Data;
using Data.Comment;
using Microsoft.EntityFrameworkCore;

namespace Infra
{
    public class EventProjectDbContext : DbContext
    {
        public EventProjectDbContext
            (DbContextOptions<EventProjectDbContext> options)
            : base(options) { }

        public DbSet<ProfileDbRecord> Profiles { get; set; }

        public DbSet<EventDbRecord> Events { get; set; }

        public DbSet<AttendingDbRecord> EventsProfiles { get; set; }

        public DbSet<CommentsProfileDbRecord> CommentsProfile { get; set; }

        public DbSet<CommentDbRecord> Comment { get; set; }

        public DbSet<FollowingDbRecord> Followings { get; set; }

        protected override void OnModelCreating(ModelBuilder b)
        {
            base.OnModelCreating(b);
            b.Entity<ProfileDbRecord>().ToTable("Profiles");
            b.Entity<EventDbRecord>().ToTable("Events");
            createProfilesTable(b);
            createEventsTable(b);
            createEventProfileTable(b);
            createCommentsProfileTable(b);
            createCommentToTable(b);
            createFollowingsTable(b);
        }

        internal static void createCommentToTable(ModelBuilder b)
        {
            const string table = "Comment";

            createPrimaryKey<CommentDbRecord>(b, table, a => new { a.EventID, a.CommentID });
            createForeignKey<CommentDbRecord, EventDbRecord>(b, table, x => x.EventID, x => x.Events);
            createForeignKey<CommentDbRecord, CommentsProfileDbRecord>(b, table, x => x.CommentID, x => x.CommentsProfile);
        }
        internal static void createCommentsProfileTable(ModelBuilder b)
        {
            const string table = "CommentsProfile";
            b.Entity<CommentsProfileDbRecord>().ToTable(table);

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

            createPrimaryKey<AttendingDbRecord>(b, table, a => new { a.EventID, a.ProfileID });
            createForeignKey<AttendingDbRecord, EventDbRecord>(b, table, x => x.EventID, x => x.Events);
            createForeignKey<AttendingDbRecord, ProfileDbRecord>(b, table, x => x.ProfileID, x => x.Profiles);
        }

        internal static void createFollowingsTable(ModelBuilder b)
        {
            const string table = "Followings";

            createPrimaryKey<FollowingDbRecord>(b, table, a => new { a.UserID, a.FollowedUserID });
            createForeignKey<FollowingDbRecord, ProfileDbRecord>(b, table, x => x.UserID, x => x.UserProfile);
            createForeignKey<FollowingDbRecord, ProfileDbRecord>(b, table, x => x.FollowedUserID, x => x.FollowedUserProfile);
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
