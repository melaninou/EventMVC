using Aids;
using Core;
using Data;
using Data.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Data
{
    [TestClass]
    public class ProfileDbRecordTests :ObjectTests<ProfileDbRecord>
    {
        protected override ProfileDbRecord getRandomTestObject()
        {
            return GetRandom.Object<ProfileDbRecord>();
        }

        [TestMethod]
        public void BaseTypeIsBasicDbRecord()
        {
            Assert.AreEqual(typeof(BasicDbRecord), typeof(ProfileDbRecord).BaseType);
        }
        
        [TestMethod]
        public void BirthDayTest()
        {
            testReadWriteProperty(() => obj.BirthDay, x => obj.BirthDay = x);
        }

        [TestMethod]
        public void AboutTextTest()
        {
            testReadWriteProperty(() => obj.AboutText, x => obj.AboutText = x);
            testNullEmptyAndWhitespaceCases(() => obj.AboutText, x => obj.AboutText = x, () => Constants.Unspecified);
        }

        [TestMethod]
        public void OccupationTest()
        {
            testReadWriteProperty(() => obj.Occupation, x => obj.Occupation = x);
            testNullEmptyAndWhitespaceCases(() => obj.Occupation, x => obj.Occupation = x, () => Constants.Unspecified);
        }

        [TestMethod]
        public void ProfileImageTest()
        {
            testReadWriteProperty(() => obj.ProfileImage, x => obj.ProfileImage = x);
            testNullEmptyAndWhitespaceCases(() => obj.ProfileImage, x => obj.ProfileImage = x, () => Constants.Unspecified);
        }

        [TestMethod]
        public void GenderTest()
        {
            testReadWriteProperty(() => obj.Gender, x => obj.Gender = x);
        }
    }
}
