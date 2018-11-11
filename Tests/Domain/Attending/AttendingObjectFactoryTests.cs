using Aids;
using Core;
using Data;
using Domain.Attending;
using Domain.Event;
using Domain.Profile;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Domain.Attending
{
    [TestClass]
    public class AttendingObjectFactoryTests : BaseTests
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            type = typeof(AttendingObjectFactory);
        }

        [TestMethod]
        public void CreateTest()
        {
            var r = GetRandom.Object<AttendingDbRecord>();
            var newEvent = new EventObject(r.Events);
            var newProfile = new ProfileObject(r.Profiles);
            string e = Constants.Unspecified;
            string p = Constants.Unspecified;

            var o = AttendingObjectFactory.Create(newEvent, newProfile, e, p);
            Assert.AreEqual(o.EventObject.DbRecord, r.Events);
            Assert.AreEqual(o.ProfileObject.DbRecord, r.Profiles);
            Assert.AreEqual(o.DbRecord.EventID, r.Events.ID);
            Assert.AreEqual(o.DbRecord.ProfileID, r.Profiles.ID);
            Assert.AreEqual(o.DbRecord.Events, r.Events);
            Assert.AreEqual(o.DbRecord.Profiles, r.Profiles);
        }


        [TestMethod]
        public void CreateWithNullArgumentsTest()
        {
            var o = AttendingObjectFactory.Create(null, null, null, null);

            Assert.AreEqual(o.DbRecord.EventID, Constants.Unspecified);
            Assert.AreEqual(o.DbRecord.ProfileID, Constants.Unspecified);
            Assert.AreEqual(o.EventObject.DbRecord, o.DbRecord.Events);
            Assert.AreEqual(o.ProfileObject.DbRecord, o.DbRecord.Profiles);
        }
    }
}



