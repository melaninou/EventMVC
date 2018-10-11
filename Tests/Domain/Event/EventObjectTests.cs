using System.Collections.Generic;
using System.Linq;
using Aids;
using Data;
using Domain.Event;
using Domain.Profile;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Domain.Common;

namespace Tests.Domain.Event
{
    [TestClass]
    public class EventObjectTests :DomainObjectTests<EventObject,EventDbRecord>
    {
        protected override EventObject getRandomTestObject()
        {
            createdWithNullArg = new EventObject(null);
            dbRecordType = typeof(EventDbRecord);
            return GetRandom.Object<EventObject>();
        }

        [TestMethod]
        public void ProfilesInUseTest()
        {
            Assert.IsNotNull(obj.ProfilesInUse);
            Assert.IsInstanceOfType(obj.ProfilesInUse, typeof(IReadOnlyList<ProfileObject>));
        }

        [TestMethod]
        public void ProfileInUseTest()
        {
            var profile = GetRandom.Object<ProfileObject>();
            Assert.IsFalse(obj.ProfilesInUse.Contains(profile));
            obj.ProfileInUse(profile);
            Assert.IsTrue(obj.ProfilesInUse.Contains(profile));
        }
    }
}
