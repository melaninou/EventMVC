using System;
using Aids;
using Facade.Comment;
using Facade.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Facade.Comment
{
    [TestClass]
    public class CommentProfileViewModelTests : ViewModelTests<CommentProfileViewModel, EmptyViewModel>
    {
        protected override CommentProfileViewModel getRandomTestObject()
        {
            return GetRandom.Object<CommentProfileViewModel>();
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
        public void ImageTest()
        {
            testReadWriteProperty(() => obj.Image, x => obj.Image = x);
        }

        [TestMethod]
        public void NameTest()
        {
            testReadWriteProperty(() => obj.Name, x => obj.Name = x);
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


    }
}
