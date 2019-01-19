using Aids;
using Data.Comment;
using Domain.CommentsProfiles;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Domain.Common;

namespace Tests.Domain.CommentsProfiles
{
    [TestClass]
    public class CommentsProfileObjectTests : DomainObjectTests<CommentsProfileObject, CommentsProfileDbRecord>
    {

        protected override CommentsProfileObject getRandomTestObject()
        {
            createdWithNullArg = new CommentsProfileObject(null);
            dbRecordType = typeof(CommentsProfileDbRecord);
            return GetRandom.Object<CommentsProfileObject>();
        }

        [TestMethod]
        public void ProfileObjectTest()
        {
            Assert.AreEqual(obj.ProfileObject.DbRecord, obj.DbRecord.Profiles);
        }

    }
}
