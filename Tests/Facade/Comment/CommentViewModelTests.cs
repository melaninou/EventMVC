using System;
using Aids;
using Facade.Comment;
using Facade.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Facade.Comment
{
    [TestClass]
    public class CommentViewModelTests :ViewModelTests<CommentViewModel, EmptyViewModel>
    {
        protected override CommentViewModel getRandomTestObject()
        {
            return GetRandom.Object<CommentViewModel>();
        }

        [TestMethod]
        public void IDTest()
        {
            testReadWriteProperty(() => obj.ID, x => obj.ID = x);
        }

        [TestMethod]
        public void CommentAddTimeTest()
        {
            DateTime rnd() => GetRandom.DateTime();
            testReadWriteProperty(() => obj.CommentAddTime, x => obj.CommentAddTime = x);
        }
        //TODO
        //[TestMethod]
        //public void UserPictureTest()
        //{
        //    testReadWriteProperty(() => obj.UserPicture, x => obj.UserPicture = x);
        //}

        //[TestMethod]
        //public void UserNameTest()
        //{
        //    testReadWriteProperty(() => obj.UserName, x => obj.UserName = x);
        //}

        [TestMethod]
        public void CommentTextTest()
        {
            testReadWriteProperty(() => obj.CommentText, x => obj.CommentText = x);
        }
    }
}
