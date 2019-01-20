using System.Collections.Generic;
using Aids;
using Core;
using Data.Comment;
using Domain.CommentProfile;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Domain.Common;

namespace Tests.Domain.CommentProfile
{
    [TestClass]
    public class CommentProfileObjectsListTests : DomainObjectsListTests<CommentProfileObjectsList, CommentProfileObject>
    {
        protected override CommentProfileObjectsList getRandomTestObject()
        {
            createWithNullArgs = new CommentProfileObjectsList(null, null);
            var l = GetRandom.Object<List<CommentProfileDbRecord>>();
            return new CommentProfileObjectsList(l, GetRandom.Object<RepositoryPage>());
        }

        [TestMethod]
        public void CanCreateWithNullArgumentTest()
        {
            Assert.IsNotNull(new CommentProfileObjectsList(null, null));
        }
    }
}
