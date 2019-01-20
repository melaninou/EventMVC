using Aids;
using Core;
using Data.Comment;
using Domain.Comment;
using Domain.CommentEvent;
using Domain.Event;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Domain.CommentEvent
{
    [TestClass]
    public class CommentEventObjectFactoryTests :BaseTests
    {

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            type = typeof(CommentEventObjectFactory);
        }

        [TestMethod]
        public void CreateTest()
        {
            var r = GetRandom.Object<CommentEventDbRecord>();
            var newEvent = new EventObject(r.Events);
            var newComment = new CommentObject(r.Comments);
            string e = Constants.Unspecified;
            string c = Constants.Unspecified;

            var o = CommentEventObjectFactory.Create(newEvent, newComment,
                e, c);
            Assert.AreEqual(o.EventObject.DbRecord, r.Events);
            Assert.AreEqual(o.CommentObject.DbRecord, r.Comments);
            Assert.AreEqual(o.DbRecord.CommentID, r.Comments.ID);
            Assert.AreEqual(o.DbRecord.EventID, r.Events.ID);
            Assert.AreEqual(o.DbRecord.Events, r.Events);
            Assert.AreEqual(o.DbRecord.Comments, r.Comments);
        }
    }
}
