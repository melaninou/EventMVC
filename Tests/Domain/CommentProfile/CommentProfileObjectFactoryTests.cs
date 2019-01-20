using Aids;
using Core;
using Data.Comment;
using Domain.Comment;
using Domain.CommentProfile;
using Domain.Profile;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Domain.CommentProfile
{
    [TestClass]
    public class CommentProfileObjectFactoryTests : BaseTests
    {

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            type = typeof(CommentProfileObjectFactory);
        }

        [TestMethod]
        public void CreateTest()
        {
            var r = GetRandom.Object<CommentProfileDbRecord>();
            var newComment = new CommentObject(r.Comments);
            var newProfile = new ProfileObject(r.Profiles);
            string c = Constants.Unspecified;
            string p = Constants.Unspecified;

            var o = CommentProfileObjectFactory.Create(newComment, newProfile,
                c, p);
            Assert.AreEqual(o.CommentObject.DbRecord, r.Comments);
            Assert.AreEqual(o.ProfileObject.DbRecord, r.Profiles);
            Assert.AreEqual(o.DbRecord.CommentID, r.Comments.ID);
            Assert.AreEqual(o.DbRecord.ProfileID, r.Profiles.ID);
            Assert.AreEqual(o.DbRecord.Profiles, r.Profiles);
            Assert.AreEqual(o.DbRecord.Comments, r.Comments);
        }
    }
}
