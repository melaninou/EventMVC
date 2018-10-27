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
        //[TestMethod]
        //public void AgeTest()
        //{
        //    testReadWriteProperty(() => obj.Age, x => obj.Age = x);
        //}

        [TestMethod]
        public void GenderTest()
        {
            testReadWriteProperty(() => obj.Gender, x => obj.Gender = x);
        }
    }
}
