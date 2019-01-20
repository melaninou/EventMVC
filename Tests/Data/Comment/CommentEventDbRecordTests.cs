using Aids;
using Core;
using Data.Comment;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Data.Comment
{
    [TestClass]
    public class CommentEventDbRecordTests :ObjectTests<CommentEventDbRecord>
    {

        protected override CommentEventDbRecord getRandomTestObject()
        {
            return GetRandom.Object<CommentEventDbRecord>();
        }

        [TestMethod]
        public void EventIDTest()
        {
            testReadWriteProperty(() => obj.EventID, x => obj.EventID = x);
            testNullEmptyAndWhitespaceCases(() => obj.EventID, x => obj.EventID = x,
                () => Constants.Unspecified);
        }

        [TestMethod]
        public void CommentIDTest()
        {
            testReadWriteProperty(() => obj.CommentID, x => obj.CommentID = x);
            testNullEmptyAndWhitespaceCases(() => obj.CommentID, x => obj.CommentID = x,
                () => Constants.Unspecified);
        }

        [TestMethod]
        public void EventsTest()
        {
            testReadWriteProperty(() => obj.Events, x => obj.Events = x);
            obj.Events = null;
            Assert.IsNull(obj.Events);
        }

        [TestMethod]
        public void CommentsTest()
        {
            testReadWriteProperty(() => obj.Comments, x => obj.Comments = x);
            obj.Comments = null;
            Assert.IsNull(obj.Comments);
        }
    }
}
