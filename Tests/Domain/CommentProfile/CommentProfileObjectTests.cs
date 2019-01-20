using Aids;
using Data.Comment;
using Domain.CommentProfile;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Domain.Common;

namespace Tests.Domain.CommentProfile
{
    [TestClass]
    public class CommentProfileObjectTests : DomainEmptyTests<CommentProfileObject,CommentProfileDbRecord>
    {
        protected override CommentProfileObject getRandomTestObject()
        {
            createdWithNullArg = new CommentProfileObject(null);
            dbRecordType = typeof(CommentProfileDbRecord);
            return GetRandom.Object<CommentProfileObject>();
        }


        [TestMethod]
        public void CommentObjectTest()
        {
            Assert.AreEqual(obj.CommentObject.DbRecord, obj.DbRecord.Comments);
        }

        [TestMethod]
        public void ProfileObjectTest()
        {
            Assert.AreEqual(obj.ProfileObject.DbRecord, obj.DbRecord.Profiles);
        }
    }
}
