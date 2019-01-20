using Aids;
using Core;
using Data.Comment;
using Domain.CommentEvent;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Tests.Domain.Common;

namespace Tests.Domain.CommentEvent
{
    [TestClass]
    public class CommentEventObjectsListTests :DomainObjectsListTests<CommentEventObjectsList, CommentEventObject>
    {
        protected override CommentEventObjectsList getRandomTestObject()
        {
            createWithNullArgs = new CommentEventObjectsList(null, null);
            var l = GetRandom.Object<List<CommentEventDbRecord>>();
            return new CommentEventObjectsList(l, GetRandom.Object<RepositoryPage>());
        }

        [TestMethod]
        public void CanCreateWithNullArgumentTest()
        {
            Assert.IsNotNull(new CommentEventObjectsList(null, null));
        }

    }
}
