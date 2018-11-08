using Aids;
using Domain.Attending;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Domain.Attending
{
    [TestClass]
    public class AttendingObjectTests :ObjectTests<AttendingObject>
    {
        protected override AttendingObject getRandomTestObject()
        {
            return GetRandom.Object<AttendingObject>();
        }

        [TestMethod]
        public void EventObjectTest()
        {
            Assert.AreEqual(obj.EventObject.DbRecord, obj.DbRecord.Events);
        }

        [TestMethod]
        public void ProfileObjectTest()
        {
            Assert.AreEqual(obj.ProfileObject.DbRecord, obj.DbRecord.Profiles);
        }

        [TestMethod]
        public void WhenCreatedWithNullArgumentsTest()
        {
            obj = new AttendingObject(null);
            Assert.AreEqual(obj.EventObject.DbRecord, obj.DbRecord.Events);
            Assert.AreEqual(obj.ProfileObject.DbRecord, obj.DbRecord.Profiles);
        }
    }
}
