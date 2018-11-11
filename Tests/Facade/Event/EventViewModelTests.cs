using System;
using System.Collections.Generic;
using Aids;
using Facade.Common;
using Facade.Event;
using Facade.Profile;
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
        public void OrganizerTest()
        {
            testReadWriteProperty(() => obj.Organizer, x => obj.Organizer = x);
        }

        [TestMethod]
        public void DescriptionTest()
        {
            testReadWriteProperty(() => obj.Description, x => obj.Description = x);
        }

        [TestMethod]
        public void InProfilesTest()
        {
            Assert.IsInstanceOfType(obj.InProfiles, typeof(List<ProfileViewModel>));
            var name = GetMember.Name<EventViewModel>(x => x.InProfiles);
            Assert.IsTrue(IsReadOnly.Property<EventViewModel>(name));
        }
    }
}
