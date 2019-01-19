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

        [TestMethod]
        public void EventObjectTest()
        {
            Assert.AreEqual(obj.EventObject.DbRecord, obj.DbRecord.Events);
        }

        [TestMethod]
        public void CommentsProfileObjectTest()
        {
            Assert.AreEqual(obj.CommentsProfileObject.DbRecord, obj.DbRecord.CommentsProfile);
        }

        [TestMethod]
        public void WhenCreatedWithNullArgumentsTest()
        {
            obj = new CommentObject(null);
            Assert.AreEqual(obj.EventObject.DbRecord, obj.DbRecord.Events);
            Assert.AreEqual(obj.CommentsProfileObject.DbRecord, obj.DbRecord.CommentsProfile);
        }
    }
}
