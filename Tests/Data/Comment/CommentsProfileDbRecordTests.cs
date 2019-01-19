using System;
using Aids;
using Core;
using Data.Comment;
using Data.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Data.Comment
{
    [TestClass]
    public class CommentsProfileDbRecordTests :ObjectTests<CommentsProfileDbRecord>
    {
        protected override CommentsProfileDbRecord getRandomTestObject()
        {
            return GetRandom.Object<CommentsProfileDbRecord>();
        }

        [TestMethod]
        public void BaseTypeIsBasicDbRecord()
        {
            Assert.AreEqual(typeof(BasicDbRecord), typeof(CommentsProfileDbRecord).BaseType);
        }

        [TestMethod]
        public void IDTest()
        {
            testReadWriteProperty(() => obj.ID, x => obj.ID = x);
            testNullEmptyAndWhitespaceCases(() => obj.ID, x => obj.ID = x, () => Constants.Unspecified);
        }

        [TestMethod]
        public void CommentAddTimeTest()
        {
            DateTime rnd() => GetRandom.DateTime(null, obj.CommentAddTime);
            testReadWriteProperty(() => obj.CommentAddTime, x => obj.CommentAddTime = x, rnd);
        }

        [TestMethod]
        public void UserNameTest()
        {
            testReadWriteProperty(() => obj.UserName, x => obj.UserName = x);
            testNullEmptyAndWhitespaceCases(() => obj.UserName, x => obj.UserName = x,
                () => Constants.Unspecified);
        }

        [TestMethod]
        public void UserPictureTest()
        {

            testReadWriteProperty(() => obj.UserPicture, x => obj.UserPicture = x);
            testNullEmptyAndWhitespaceCases(() => obj.UserPicture, x => obj.UserPicture = x,
                () => Constants.Unspecified);
        }

        [TestMethod]
        public void CommentTextTest()
        {

            testReadWriteProperty(() => obj.CommentText, x => obj.CommentText = x);
            testNullEmptyAndWhitespaceCases(() => obj.CommentText, x => obj.CommentText = x,
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
    }
}
