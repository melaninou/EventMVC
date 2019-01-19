using System.Collections.Generic;
using System.Linq;
using Aids;
using Data;
using Domain.Event;
using EventProject.Controllers;
using Infra;
using Infra.Event;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.EventProject.Controllers
{
    [TestClass]
    public class EventControllerTests : ControllerTests<EventProjectDbContext,
    EventController,EventObject,EventDbRecord>
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            repository = new EventObjectsRepository(db);
            controller = "events";
            detailsViewCaption = "Events";
        }
        protected override string createDbRecord()
        {
            var r = GetRandom.Object<EventDbRecord>();
            if (db.Events.Contains(r) == false) db.Events.Add(r);
            db.SaveChanges();
            specificStringsToTestInView = new List<string> {
                $"{r.ID}",
                $"{r.Name}",
                $"{r.Date}",
                $"{r.Location}",
                $"{r.Type}",
                $"{r.Organizer}"
            };
            editViewCaption = $"Event ({r.ID})";
            return r.ID;
        }
        protected override void initializeDatabase(EventProjectDbContext context)
        {
            EventDbTableInitializer.Initialize(context);
        }

        [TestMethod]
        public void DeleteConfirmedTest()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void AttendingTest()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void NotAttendingTest()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void CalendarTest()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void AddCommentTest()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void RegisterTest()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void propertiesTest()
        {
            Assert.Inconclusive();
        }
    }
}
