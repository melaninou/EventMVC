using Aids;
using Core;
using Data.Comment;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Data.Comment
{
    [TestClass]
    public class CommentDbRecordTests : ObjectTests<CommentDbRecord>
    {
        protected override CommentDbRecord getRandomTestObject()
        {
            return GetRandom.Object<CommentDbRecord>();
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
        public void CommentsProfileTest()
        {
            testReadWriteProperty(() => obj.CommentsProfile, x => obj.CommentsProfile = x);
            obj.CommentsProfile = null;
            Assert.IsNull(obj.CommentsProfile);
        }
    }
}
