using System.Linq;
using Aids;
using Data;
using Infra;
using Infra.Event;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Infra.Event
{
    [TestClass]
    public class EventObjectsRepositoryTests :BaseTests
    {

        protected readonly EventObjectsRepository repository;
        protected const int count = 0;
        protected readonly EventProjectDbContext db;

        public EventObjectsRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<EventProjectDbContext>()
                .UseInMemoryDatabase("TestDb").Options;
            db = new EventProjectDbContext(options);
            repository = new EventObjectsRepository(db);
        }

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            type = typeof(EventObjectsRepository);
            Assert.AreEqual(0, db.Events.Count());
            for (var i = 0; i < count; i++)
            {
                db.Events.Add(GetRandom.Object<EventDbRecord>());
                db.SaveChanges();
            }
        }

        [TestMethod]
        public void CanCreate()
        {
            Assert.IsNotNull(new EventObjectsRepository(null));
        }

        //todo
        /*[TestMethod]
        public async Task GetEventListTest()
        {
            var l = await repository.GetEventList();
            Assert.AreEqual(count, l.Count);
        }*/
        
    }
}
