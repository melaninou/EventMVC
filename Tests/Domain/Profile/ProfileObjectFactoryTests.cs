using System;
using Aids;
using Core;
using Domain.Profile;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Domain.Profile
{
    [TestClass]
    public class ProfileObjectFactoryTests : BaseTests
    {
        private string id;
        private string name;
        private string location;
        private DateTime birthDay;
        private ProfileGender gender;
        private ProfileObject o;
        private string occupation;
        private string aboutText;
        private string profileImage;

        private void initializeTestData()
        {
            id = GetRandom.String();
            name = GetRandom.String();
            location = GetRandom.String();
            gender = ProfileGender.Female;
            birthDay = GetRandom.DateTime();
            aboutText = GetRandom.String();
            occupation = GetRandom.String();
            profileImage = GetRandom.String();
        }
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            type = typeof(ProfileObjectFactory);
            initializeTestData();
        }

        private void validateResults(string i = Constants.Unspecified,
            string n = Constants.Unspecified, string l = Constants.Unspecified,
            ProfileGender g = ProfileGender.Female, DateTime? b = null,
            string oc = Constants.Unspecified, string a = Constants.Unspecified,
            string p = Constants.Unspecified)
        {
            Assert.AreEqual(i, o.DbRecord.ID);
            Assert.AreEqual(n, o.DbRecord.Name);
            Assert.AreEqual(l, o.DbRecord.Location);
            Assert.AreEqual(g, o.DbRecord.Gender);
            Assert.AreEqual(b, o.DbRecord.BirthDay);
            Assert.AreEqual(oc, o.DbRecord.Occupation);
            Assert.AreEqual(a, o.DbRecord.AboutText);
            Assert.AreEqual(p, o.DbRecord.ProfileImage);
        }

        [TestMethod]
        public void CreateTest()
        {
            o = ProfileObjectFactory.Create(id, name, location, gender,
                birthDay, occupation, aboutText,profileImage);
            validateResults(id, name, location, gender, birthDay,
                occupation, aboutText, profileImage);
        }
    }
}
