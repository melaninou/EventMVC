using System.Collections.Generic;
using Aids;
using Core;
using Data;
using Domain.Profile;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Domain.Common;

namespace Tests.Domain.Profile
{
    [TestClass]
    public class ProfileObjectsListTests :DomainObjectsListTests<ProfileObjectsList,ProfileObject>
    {
        protected override ProfileObjectsList getRandomTestObject()
        {
            createWithNullArgs = new ProfileObjectsList(null, null);
            var l = GetRandom.Object<List<ProfileDbRecord>>();
            return new ProfileObjectsList(l, GetRandom.Object<RepositoryPage>());
        }
    }
}
