using Aids;
using Core;
using Domain.Comment;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Tests.Domain.Comment
{
    [TestClass]
    public class CommentObjectFactoryTests :BaseTests
    {
        private string id;
        private DateTime commentAddTime;
        private string commentText;
        private string subject;
        private string email;
        private CommentObject o;


        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            type = typeof(CommentObjectFactory);
            initializeTestData();
        }

        [TestMethod]
        public void CreateTest()
        {
            o = CommentObjectFactory.Create(id, commentAddTime, commentText,
                subject, email);
            validateResults(id, commentAddTime, commentText,
                subject, email);
        }

        private void initializeTestData()
        {
            id = GetRandom.String();
            commentAddTime = DateTime.Today;
            commentText = GetRandom.String();
            subject = GetRandom.String();
            email = GetRandom.String();
        }
        private void validateResults(string i = Constants.Unspecified,
            DateTime? c = null, string t = Constants.Unspecified, string s = Constants.Unspecified,
            string e = Constants.Unspecified)
        {
            Assert.AreEqual(i, o.DbRecord.ID);
            Assert.AreEqual(c, o.DbRecord.CommentAddTime);
            Assert.AreEqual(t, o.DbRecord.CommentText);
            Assert.AreEqual(s, o.DbRecord.Name);
        }
    }
}
