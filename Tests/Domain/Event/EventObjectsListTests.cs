using System.Collections.Generic;
using Aids;
using Core;
using Data;
using Domain.Event;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Domain.Common;

namespace Tests.Domain.Event
{
    [TestClass]
    public class EventObjectsListTests :DomainObjectsListTests<EventObjectsList,EventObject>
    {
        protected override EventObjectsList getRandomTestObject()
        {
            createWithNullArgs = new EventObjectsList(null,null);
            var l = GetRandom.Object<List<EventDbRecord>>();
            return new EventObjectsList(l, GetRandom.Object<RepositoryPage>());
        }

        [TestMethod]
        public void CanCreateWithNullArgumentTest()
        {
            Assert.IsNotNull(new EventObjectsList(null, null));
        }
    }
}
