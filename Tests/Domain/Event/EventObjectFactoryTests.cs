﻿using System;
using Aids;
using Core;
using Domain.Event;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Domain.Event
{
    [TestClass]
    public class EventObjectFactoryTests :BaseTests
    {
        private string id;
        private string name;
        private string location;
        private DateTime date;
        private EventType evType;
        private string organiser;
        private string description;
        private EventObject o;
        private string eventImage;
        private DateTime dateCreated;

        private void initializeTestData()
        {
            id = GetRandom.String();
            name = GetRandom.String();
            location = GetRandom.String();
            date = DateTime.Today;
            evType = EventType.Other;
            organiser = GetRandom.String();
            description = GetRandom.String();
            eventImage = GetRandom.String();
            dateCreated = DateTime.Today;
        }

        private void validateResults(string i = Constants.Unspecified, string n = Constants.Unspecified,
            string l = Constants.Unspecified, DateTime? d = null, EventType t = EventType.Other,
            string org = Constants.Unspecified, string desc = Constants.Unspecified,
            string img = Constants.Unspecified, DateTime? dc = null)
        {
            Assert.AreEqual(i, o.DbRecord.ID);
            Assert.AreEqual(n, o.DbRecord.Name);
            Assert.AreEqual(l, o.DbRecord.Location);
            Assert.AreEqual(d, o.DbRecord.Date);
            Assert.AreEqual(t, o.DbRecord.Type);
            Assert.AreEqual(org, o.DbRecord.Organizer);
            Assert.AreEqual(desc, o.DbRecord.Description);
            Assert.AreEqual(img, o.DbRecord.EventImage);
            Assert.AreEqual(dc, o.DbRecord.DateCreated);
        }

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            type = typeof(EventObjectFactory);
            initializeTestData();
        }

        [TestMethod]
        public void CreateTest()
        {
            o = EventObjectFactory.Create(id, name, location, date, evType, organiser,
            description, eventImage, dateCreated);
            validateResults(id, name, location, date, evType, organiser,
            description, eventImage, dateCreated);
        }
    }
}
