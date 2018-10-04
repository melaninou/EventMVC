using Aids;
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
        public void BaseTypeIsUniqueDbRecord()
        {
            Assert.AreEqual(typeof(UniqueDbRecord), typeof(ProfileDbRecord).BaseType);
        }

    }
}
