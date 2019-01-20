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

        [TestMethod]
        public void SubjectTest()
        {
            testReadWriteProperty(() => obj.Subject, x => obj.Subject = x);
        }

        [TestMethod]
        public void EmailTest()
        {
            testReadWriteProperty(() => obj.Email, x => obj.Email = x);
        }

        [TestMethod]
        public void CommentTextTest()
        {
            testReadWriteProperty(() => obj.CommentText, x => obj.CommentText = x);
        }

        [TestMethod]
        public void ProfileViewModelTest()
        {
            testReadWriteProperty(() => obj.ProfileViewModel, x => obj.ProfileViewModel = x);
        }
    }
}


