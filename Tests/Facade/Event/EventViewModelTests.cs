using System;
using Aids;
using Facade.Common;
using Facade.Event;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Facade.Event
{
    [TestClass]
    public class EventViewModelTests :ViewModelTests<EventViewModel, BasicViewModel>
    {
        protected override EventViewModel getRandomTestObject()
        {
            return GetRandom.Object<EventViewModel>();
        }

        [TestMethod]
        public void TypeTest()
        {
            testReadWriteProperty(() => obj.Type, x => obj.Type = x);
        }

        [TestMethod]
        public void DateTest()
        {
            DateTime rnd() => GetRandom.DateTime();
            testReadWriteProperty(() => obj.Date, x => obj.Date = x);
        }

        [TestMethod]
        public void OrganiserTest()
        {
            testReadWriteProperty(() => obj.Organiser, x => obj.Organiser = x);
        }

        [TestMethod]
        public void DescriptionTest()
        {
            testReadWriteProperty(() => obj.Description, x => obj.Description = x);
        }
    }
}
