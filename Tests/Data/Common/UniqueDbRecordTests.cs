using Aids;
using Core;
using Data.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Data.Common
{
    [TestClass]
    public class UniqueDbRecordTests : ObjectTests<UniqueDbRecord>
    {
        private class testClass : UniqueDbRecord { }

        protected override UniqueDbRecord getRandomTestObject()
        {
            return GetRandom.Object<testClass>();
        }

        [TestMethod]
        public void IsAbstract()
        {
            Assert.IsTrue(typeof(UniqueDbRecord).IsAbstract);
        }

        [TestMethod]
        public void IDTest()
        {
            testReadWriteProperty(() => obj.ID, x => obj.ID = x);
            testNullEmptyAndWhitespaceCases(() => obj.ID, x => obj.ID = x, () => Constants.Unspecified);
        }

        [TestMethod]
        public void NameTest()
        {
            testReadWriteProperty(() => obj.Name, x => obj.Name = x);
            testNullEmptyAndWhitespaceCases(() => obj.Name, x => obj.Name = x, () => Constants.Unspecified);
        }

        [TestMethod]
        public void LocationTest()
        {
            testReadWriteProperty(() => obj.Location, x => obj.Location = x);
            testNullEmptyAndWhitespaceCases(() => obj.Location, x => obj.Location = x, () => Constants.Unspecified);
        }
    }
}
