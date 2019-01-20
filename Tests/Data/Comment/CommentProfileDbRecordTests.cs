using Aids;
using Core;
using Data.Comment;
using Data.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Data.Comment
{
    [TestClass]
    public class CommentProfileDbRecordTests : ObjectTests<CommentProfileDbRecord>
    {
        protected override CommentProfileDbRecord getRandomTestObject()
        {
            return GetRandom.Object<CommentProfileDbRecord>();
        }

        [TestMethod]
        public void BaseTypeIsEmptyDbRecord()
        {
            Assert.AreEqual(typeof(EmptyDbRecord), typeof(CommentProfileDbRecord).BaseType);
        }

        [TestMethod]
        public void CommentIDTest()
        {
            testReadWriteProperty(() => obj.CommentID, x => obj.CommentID = x);
            testNullEmptyAndWhitespaceCases(() => obj.CommentID, x => obj.CommentID = x,
                () => Constants.Unspecified);
        }

        [TestMethod]
        public void ProfileIDTest()
        {
            testReadWriteProperty(() => obj.ProfileID, x => obj.ProfileID = x);
            testNullEmptyAndWhitespaceCases(() => obj.ProfileID, x => obj.ProfileID = x,
                () => Constants.Unspecified);
        }

        [TestMethod]
        public void ProfilesTest()
        {
            testReadWriteProperty(() => obj.Profiles, x => obj.Profiles = x);
            obj.Profiles = null;
            Assert.IsNull(obj.Profiles);
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
