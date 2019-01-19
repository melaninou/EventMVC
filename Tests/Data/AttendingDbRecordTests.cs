using Aids;
using Core;
using Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Data
{
    [TestClass]
    public class AttendingDbRecordTests :ObjectTests<AttendingDbRecord>
    {
        protected override AttendingDbRecord getRandomTestObject()
        {
            return GetRandom.Object<AttendingDbRecord>();
        }

        [TestMethod]
        public void EventIDTest()
        {
            testReadWriteProperty(() => obj.EventID, x => obj.EventID = x);
            testNullEmptyAndWhitespaceCases(() => obj.EventID, x => obj.EventID = x, () => Constants.Unspecified);
        }

        [TestMethod]
        public void ProfileIDTest()
        {
            testReadWriteProperty(() => obj.ProfileID, x => obj.ProfileID = x);
            testNullEmptyAndWhitespaceCases(() => obj.ProfileID, x => obj.ProfileID = x, () => Constants.Unspecified);
        }

        [TestMethod]
        public void EventsTest()
        {
            testReadWriteProperty(() => obj.Events, x => obj.Events = x);
            obj.Events = null;
            Assert.IsNull(obj.Events);
        }

        [TestMethod]
        public void ProfilesTest()
        {
            testReadWriteProperty(() => obj.Profiles, x => obj.Profiles = x);
            obj.Profiles = null;
            Assert.IsNull(obj.Profiles);
        }
    }
}
