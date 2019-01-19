using Aids;
using Core;
using Data.Comment;
using Domain.Comment;
using Domain.CommentsProfiles;
using Domain.Event;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Domain.Comment
{
    [TestClass]
    public class CommentObjectFactoryTests :BaseTests
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            type = typeof(CommentObjectFactory);
        }

        [TestMethod]
        public void CreateTest()
        {
            var r = GetRandom.Object<CommentDbRecord>();
            var newComment = new CommentsProfileObject(r.CommentsProfile);
            var newEvent = new EventObject(r.Events);
            string c = Constants.Unspecified;
            string e = Constants.Unspecified;

            var o = CommentObjectFactory.Create(newEvent, newComment,
                e, c);
            Assert.AreEqual(o.CommentsProfileObject.DbRecord, r.CommentsProfile);
            Assert.AreEqual(o.EventObject.DbRecord, r.Events);
            Assert.AreEqual(o.DbRecord.EventID, r.Events.ID);
            Assert.AreEqual(o.DbRecord.CommentID, r.CommentsProfile.ID);
            Assert.AreEqual(o.DbRecord.CommentsProfile, r.CommentsProfile);
            Assert.AreEqual(o.DbRecord.Events, r.Events);
        }

        [TestMethod]
        public void CreateWithNullArgumentsTest()
        {
            var o = CommentObjectFactory.Create(null, null, null, null);

            Assert.AreEqual(o.DbRecord.CommentID, Constants.Unspecified);
            Assert.AreEqual(o.DbRecord.EventID, Constants.Unspecified);
            Assert.AreEqual(o.CommentsProfileObject.DbRecord, o.DbRecord.CommentsProfile);
            Assert.AreEqual(o.EventObject.DbRecord, o.DbRecord.Events);
        }
    }
}
