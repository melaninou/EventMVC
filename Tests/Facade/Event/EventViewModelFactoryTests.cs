using Aids;
using Domain.Event;
using Facade.Event;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Facade.Event
{
    [TestClass]
    public class EventViewModelFactoryTests :BaseTests
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            type = typeof(EventViewModelFactory);
        }

        [TestMethod]
        public void CreateTest()
        {
            var o = GetRandom.Object<EventObject>();
            var v = EventViewModelFactory.Create(o);
            Assert.AreEqual(v.Name, o.DbRecord.Name);
            Assert.AreEqual(v.ID, o.DbRecord.ID);
            Assert.AreEqual(v.Location, o.DbRecord.Location);
            Assert.AreEqual(v.Type,o.DbRecord.Type);
            Assert.AreEqual(v.Date, o.DbRecord.Date);
            Assert.AreEqual(v.Organizer,o.DbRecord.Organizer);
            Assert.AreEqual(v.Description, o.DbRecord.Description);
        }
    }
}
