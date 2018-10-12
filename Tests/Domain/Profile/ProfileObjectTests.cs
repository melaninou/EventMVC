using System.Collections.Generic;
using System.Linq;
using Aids;
using Data;
using Domain.Event;
using Domain.Profile;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Domain.Common;

namespace Tests.Domain.Profile
{
    [TestClass]
    public class ProfileObjectTests :DomainObjectTests<ProfileObject, ProfileDbRecord>
    {
        protected override ProfileObject getRandomTestObject()
        {
            createdWithNullArg = new ProfileObject(null);
            dbRecordType = typeof(ProfileDbRecord);
            return GetRandom.Object<ProfileObject>();
        }

        [TestMethod]
        public void UsedInEventsTest()
        {
            Assert.IsNotNull(obj.UsedInEvents);
            Assert.IsInstanceOfType(obj.UsedInEvents, typeof(IReadOnlyList<EventObject>));
        }

        [TestMethod]
        public void UsedInEventTest()
        {
            var newEvent = GetRandom.Object<EventObject>();
            Assert.IsFalse(obj.UsedInEvents.Contains(newEvent));
            obj.UsedInEvent(newEvent);
            Assert.IsTrue(obj.UsedInEvents.Contains(newEvent));
        }
    }
}
