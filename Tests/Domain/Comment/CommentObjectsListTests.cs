using System.Collections.Generic;
using Aids;
using Core;
using Data.Comment;
using Domain.Comment;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Domain.Common;

namespace Tests.Domain.Comment
{
    [TestClass]
    public class CommentObjectsListTests :DomainObjectsListTests<
    CommentObjectsList, CommentObject>
    {
        protected override CommentObjectsList getRandomTestObject()
        {
            createWithNullArgs = new CommentObjectsList(null, null);
            var l = GetRandom.Object<List<CommentDbRecord>>();
            return new CommentObjectsList(l, GetRandom.Object<RepositoryPage>());
        }
    }
}
