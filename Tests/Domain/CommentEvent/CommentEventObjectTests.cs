using Aids;
using Data.Comment;
using Domain.CommentEvent;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Domain.Common;

namespace Tests.Domain.CommentEvent
{
    [TestClass]
    public class CommentEventObjectTests :DomainEmptyTests<CommentEventObject,CommentEventDbRecord>
    {

        protected override CommentEventObject getRandomTestObject()
        {
            createdWithNullArg = new CommentEventObject(null);
            dbRecordType = typeof(CommentEventDbRecord);
            return GetRandom.Object<CommentEventObject>();
        }


        [TestMethod]
        public void EventObjectTest()
        {
            Assert.AreEqual(obj.EventObject.DbRecord, obj.DbRecord.Events);
        }

        [TestMethod]
        public void CommentObjectTest()
        {
            Assert.AreEqual(obj.CommentObject.DbRecord, obj.DbRecord.Comments);
        }
    }
}
