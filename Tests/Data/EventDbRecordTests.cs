using System;
using System.Diagnostics.CodeAnalysis;
using Aids;
using Core;
using Data;
using Data.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Data
{
    [TestClass]
    public class EventDbRecordTests : ObjectTests<EventDbRecord>
    {
        protected override EventDbRecord getRandomTestObject()
        {
            return GetRandom.Object<EventDbRecord>();
        }

        [TestMethod]
        public void BaseTypeIsBasicDbRecord()
        {
            Assert.AreEqual(typeof(BasicDbRecord), typeof(EventDbRecord).BaseType);
        }
        [TestMethod]
        public void IDTest()
        {
            testReadWriteProperty(() => obj.ID, x => obj.ID = x);
            testNullEmptyAndWhitespaceCases(() => obj.ID, x => obj.ID = x, () => Constants.Unspecified);
        }
        [TestMethod]
        public void TypeTest()
        {
            testReadWriteProperty(() => obj.Type, x => obj.Type = x);
        }

        [TestMethod]
        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public void DateTest()
        {
            DateTime rnd() => GetRandom.DateTime(null, obj.Date);
            testReadWriteProperty(() => obj.Date, x => obj.Date = x, rnd);
        }

        [TestMethod]
        public void OrganizerTest()
        {
            testReadWriteProperty(() => obj.Organizer, x => obj.Organizer = x);
            testNullEmptyAndWhitespaceCases(() => obj.Organizer, x => obj.Organizer = x, () => Constants.Unspecified);
        }

        [TestMethod]
        public void DescriptionTest()
        {
            testReadWriteProperty(() => obj.Description, x => obj.Description = x);
            testNullEmptyAndWhitespaceCases(() => obj.Description, x => obj.Description = x,
                () => Constants.Unspecified);
        }

        [TestMethod]
        public void EventImageTest()
        {
            testReadWriteProperty(() => obj.EventImage, x => obj.EventImage = x);
            testNullEmptyAndWhitespaceCases(() => obj.EventImage, x => obj.EventImage = x,
                () => Constants.Unspecified);
        }

        [TestMethod]
        public void DateCreatedTest()
        {
            testReadWriteProperty(() => obj.DateCreated, x => obj.DateCreated = x);
        }
    }
}
