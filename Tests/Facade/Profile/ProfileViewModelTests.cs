using Aids;
using Facade.Common;
using Facade.Profile;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Facade.Profile
{
    [TestClass]
    public class ProfileViewModelTests :ViewModelTests<ProfileViewModel, BasicViewModel>
    {
        protected override ProfileViewModel getRandomTestObject()
        {
            return GetRandom.Object<ProfileViewModel>();
        }
        [TestMethod]
        public void BirthDayTest()
        {
            testReadWriteProperty(() => obj.BirthDay, x => obj.BirthDay = x);
        }

        [TestMethod]
        public void GenderTest()
        {
            testReadWriteProperty(() => obj.Gender, x => obj.Gender = x);
        }

        [TestMethod]
        public void AboutTextTest()
        {
            testReadWriteProperty(() => obj.AboutText, x => obj.AboutText = x);
        }

        [TestMethod]
        public void OccupationTest()
        {
            testReadWriteProperty(() => obj.Occupation, x => obj.Occupation = x);
        }

        [TestMethod]
        public void ProfileImageTest()
        {
            testReadWriteProperty(() => obj.ProfileImage, x => obj.ProfileImage = x);
        }
    }
}
