using Aids;
using Domain.Profile;
using Facade.Profile;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Facade.Profile
{
    [TestClass]
    public class ProfileViewModelFactoryTests :BaseTests
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            type = typeof(ProfileViewModelFactory);
        }

        [TestMethod]
        public void CreateTest()
        {
            var o = GetRandom.Object<ProfileObject>();
            var v = ProfileViewModelFactory.Create(o);
            Assert.AreEqual(v.Name, o.DbRecord.Name);
            Assert.AreEqual(v.ID, o.DbRecord.ID);
            Assert.AreEqual(v.Location, o.DbRecord.Location);
            Assert.AreEqual(v.BirthDay, o.DbRecord.BirthDay);
            Assert.AreEqual(v.Occupation, o.DbRecord.Occupation);
            Assert.AreEqual(v.AboutText, o.DbRecord.AboutText);
            Assert.AreEqual(v.ProfileImage, o.DbRecord.ProfileImage);
        }
    }
}
