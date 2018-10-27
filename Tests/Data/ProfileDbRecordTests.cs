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
        public void IDTest()
        {
            testReadWriteProperty(() => obj.ID, x => obj.ID = x);
            testNullEmptyAndWhitespaceCases(() => obj.ID, x => obj.ID = x, () => Constants.Unspecified);
        }



        [TestMethod]
        public void GenderTest()
        {
            testReadWriteProperty(() => obj.Gender, x => obj.Gender = x);
        }
    }
}
