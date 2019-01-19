using System;
using Aids;
using Core;
using Domain.CommentsProfiles;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Domain.CommentsProfiles
{
    [TestClass]
    public class CommentsProfileObjectFactoryTests : BaseTests
    {
        private string id;
        private string userName;
        private DateTime commentAddTime;
        private string userPicture;
        private string commentText;
        private string profileID;
        private CommentsProfileObject o;

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            type = typeof(CommentsProfileObjectFactory);
            initializeTestData();
        }

        [TestMethod]
        public void CreateTest()
        {
            o = CommentsProfileObjectFactory.Create(id, userName, commentAddTime,
                userPicture, commentText, profileID);
            validateResults(id,userName,commentAddTime,userPicture,
                commentText,profileID);
        }

        private void initializeTestData()
        {
            id = GetRandom.String();
            userName = GetRandom.String();
            commentAddTime = DateTime.Today;
            userPicture = GetRandom.String();
            commentText = GetRandom.String();
            profileID = GetRandom.String();
        }
        private void validateResults(string i = Constants.Unspecified,
            string u = Constants.Unspecified, DateTime? c = null,
            string up = Constants.Unspecified, string ct = Constants.Unspecified,
            string p = Constants.Unspecified)
        {
            Assert.AreEqual(i, o.DbRecord.ID);
            Assert.AreEqual(u, o.DbRecord.UserName);
            Assert.AreEqual(c, o.DbRecord.CommentAddTime);
            Assert.AreEqual(up, o.DbRecord.UserPicture);
            Assert.AreEqual(ct, o.DbRecord.CommentText);
            Assert.AreEqual(p, o.DbRecord.ProfileID);
        }
    }
}
