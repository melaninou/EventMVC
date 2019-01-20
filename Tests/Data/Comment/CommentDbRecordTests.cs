using System;
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
        public void IDTest()
        {
            testReadWriteProperty(() => obj.ID, x => obj.ID = x);
            testNullEmptyAndWhitespaceCases(() => obj.ID, x => obj.ID = x,
                () => Constants.Unspecified);
        }

        [TestMethod]
        public void CommentAddTimeTest()
        {
            DateTime rnd() => GetRandom.DateTime(null, obj.CommentAddTime);
            testReadWriteProperty(() => obj.CommentAddTime, 
                x => obj.CommentAddTime = x, rnd);
        }

        [TestMethod]
        public void CommentTextTest()
        {
            testReadWriteProperty(() => obj.CommentText, x => obj.CommentText = x);
            testNullEmptyAndWhitespaceCases(() => obj.CommentText, x => obj.CommentText = x,
                () => Constants.Unspecified);
        }
    }
}
