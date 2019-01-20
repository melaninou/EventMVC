using System;
using System.Linq;
using Aids;
using Data;
using Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Infra
{
    [TestClass]
    public class EventProjectDbContextTests :BaseTests
    {

        protected readonly EventProjectDbContext db;
        private class testClass : EventProjectDbContext
        {
            public testClass(DbContextOptions<EventProjectDbContext> options) : base(options)
            {
            }

            public ModelBuilder RunOnModelCreating()
            {
                var set = new ConventionSet();
                var mb = new ModelBuilder(set);
                OnModelCreating(mb);
                return mb;
            }
        }

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            type = typeof(EventProjectDbContext);
        }

        [TestMethod]
        public void OnModelCreatingTest()
        {
            var o = new DbContextOptions<EventProjectDbContext>();
            var context = new testClass(o);
            var mb = context.RunOnModelCreating();
            testHasEventProfileEntities(mb);
        }

        [TestMethod]
        public void EventsTest()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void ProfilesTest()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void EventsProfilesTest()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void CommentProfileTest()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void CommentsTest()
        {
            Assert.Inconclusive();
        }
        [TestMethod]
        public void CommentEventTest()
        {
            Assert.Inconclusive();
        }

        private void testHasEventProfileEntities(ModelBuilder mb)
        {
            testEntity<EventDbRecord>(mb);
            testEntity<ProfileDbRecord>(mb);
            var entity = testEntity<AttendingDbRecord>(mb, true, 2);
            var eventID = GetMember.Name<AttendingDbRecord>(x => x.EventID);
            var profileID = GetMember.Name<AttendingDbRecord>(x => x.ProfileID);
            testPrimaryKey(entity,eventID, profileID);
            testForeignKey(entity, eventID, typeof(EventDbRecord));
            testForeignKey(entity, profileID, typeof(ProfileDbRecord));
        }

        private static IMutableEntityType testEntity<T>(ModelBuilder mb, bool hasPrimaryKey = false,
            int foreignKeysCount = 0)
        {
            var name = typeof(T).FullName;
            var entity = mb.Model.FindEntityType(name);
            Assert.IsNotNull(entity, name);
            testPrimaryKey(entity, hasPrimaryKey);
            testForeignKey(entity, foreignKeysCount);
            return entity;
        }
        private static void testForeignKey(IMutableEntityType entity, int foreignKeysCount)
        {
            Assert.AreEqual(foreignKeysCount, entity.GetForeignKeys().Count());
        }

        private static void testPrimaryKey(IMutableEntityType entity, bool hasPrimaryKey)
        {
            if (hasPrimaryKey) Assert.IsNotNull(entity.FindPrimaryKey());
            else Assert.IsNull(entity.FindPrimaryKey());
        }
        private void testForeignKey(IMutableEntityType entity, string name = null, Type t = null)
        {
            var keys = entity.GetForeignKeys();
            foreach (var k in keys)
            {
                var key = k.Properties.FirstOrDefault(x => x.Name == name);
                if (key is null) continue;
                Assert.AreEqual(k.PrincipalEntityType.Name, t?.FullName);
                return;
            }
            Assert.Fail("No foreign key found");
        }

        private void testPrimaryKey(IMutableEntityType entity, params string[] values)
        {
            var key = entity.FindPrimaryKey();
            if (values is null) Assert.IsNull(key);
            else
                foreach (var v in values)
                {
                    Assert.IsNotNull(key.Properties.FirstOrDefault(x => x.Name == v));
                }
        }

    }
}
