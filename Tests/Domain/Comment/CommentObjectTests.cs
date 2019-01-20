using Aids;
using Domain.Comment;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Domain.Comment
{
    [TestClass]
    public class CommentObjectTests : ObjectTests<CommentObject>
    {
        protected override CommentObject getRandomTestObject()
        {
            return GetRandom.Object<CommentObject>();
        }
    }
}
