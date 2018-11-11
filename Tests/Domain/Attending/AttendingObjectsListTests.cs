using System.Collections.Generic;
using Aids;
using Core;
using Data;
using Domain.Attending;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Domain.Common;

namespace Tests.Domain.Attending
{
    [TestClass]
    public class AttendingObjectsListTests :DomainObjectsListTests
        <AttendingObjectsList,AttendingObject>
    {
        protected override AttendingObjectsList getRandomTestObject()
        {
            createWithNullArgs = new AttendingObjectsList(null,null);
            var l = GetRandom.Object<List<AttendingDbRecord>>();
            return new AttendingObjectsList(l,GetRandom.Object<RepositoryPage>());
        }
    }
}
