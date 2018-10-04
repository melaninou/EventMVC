using System;
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
        public void BaseTypeIsUniqueDbRecord()
        {
            Assert.AreEqual(typeof(UniqueDbRecord), typeof(EventDbRecord).BaseType);
        }


        [TestMethod]
        public void DateTest()
        {
            DateTime rnd() => GetRandom.DateTime(null, obj.Date);
            testReadWriteProperty(() => obj.Date, x => obj.Date = x, rnd);
        }

        [TestMethod]
        public void OrganiserTest()
        {
            testReadWriteProperty(() => obj.Organiser, x => obj.Organiser = x);
            testNullEmptyAndWhitespaceCases(() => obj.Organiser, x => obj.Organiser = x, () => Constants.Unspecified);
        }

        [TestMethod]
        public void DescriptionTest()
        {
            testReadWriteProperty(() => obj.Description, x => obj.Description = x);
            testNullEmptyAndWhitespaceCases(() => obj.Description, x => obj.Description = x,
                () => Constants.Unspecified);
        }
    }
}
