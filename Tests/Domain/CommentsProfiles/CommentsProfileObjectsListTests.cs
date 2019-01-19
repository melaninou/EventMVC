using System.Collections.Generic;
using Aids;
using Core;
using Data.Comment;
using Domain.CommentsProfiles;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Domain.Common;

namespace Tests.Domain.CommentsProfiles
{
    [TestClass]
    public class CommentsProfileObjectsListTests :DomainObjectsListTests<CommentsProfileObjectsList, CommentsProfileObject>
    {
        protected override CommentsProfileObjectsList getRandomTestObject()
        {
            createWithNullArgs = new CommentsProfileObjectsList(null, null);
            var l = GetRandom.Object<List<CommentsProfileDbRecord>>();
            return new CommentsProfileObjectsList(l, GetRandom.Object<RepositoryPage>());
        }

        [TestMethod]
        public void CanCreateWithNullArgumentTest()
        {
            Assert.IsNotNull(new CommentsProfileObjectsList(null, null));
        }
    }
}
