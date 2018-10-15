using Aids;
using Core;
using Domain.Profile;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Domain.Profile
{
    [TestClass]
    public class ProfileObjectFactoryTests :BaseTests
    {
        private string id;
        private string name;
        private string location;
        private string age;
        private ProfileGender gender;
        private ProfileObject o;

        private void initializeTestData()
        {
            id = GetRandom.String();
            name = GetRandom.String();
            location = GetRandom.String();
            age = GetRandom.String();
            gender = ProfileGender.Female;
        }

        private void validateResults(string i = Constants.Unspecified,
            string n = Constants.Unspecified, string l = Constants.Unspecified,
            string a = Constants.Unspecified, ProfileGender g = ProfileGender.Female)
        {
            Assert.AreEqual(i, o.DbRecord.ID);
            Assert.AreEqual(n, o.DbRecord.Name);
            Assert.AreEqual(l, o.DbRecord.Location);
            Assert.AreEqual(a, o.DbRecord.Age);
            Assert.AreEqual(g, o.DbRecord.Gender);
        }
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            type = typeof(ProfileObjectFactory);
            initializeTestData();
        }

        [TestMethod]
        public void CreateTest()
        {
            o = ProfileObjectFactory.Create(id, name, location, age, gender);
            validateResults(id,name,location,age,gender);
        }

        [TestMethod]
        public void CreateWithNullArgumentsTest()
        {
            o = ProfileObjectFactory.Create(null, null, null, null,gender);
            validateResults();
        }
    }
}
