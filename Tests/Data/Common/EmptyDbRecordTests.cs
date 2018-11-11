using Aids;
using Data.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Data.Common
{
    [TestClass]
    public class EmptyDbRecordTests: ObjectTests<EmptyDbRecord>
    {
        private class testClass : EmptyDbRecord { }

        protected override EmptyDbRecord getRandomTestObject()
        {
            return GetRandom.Object<testClass>();
        }

        [TestMethod]
        public void IsAbstract()
        {
            Assert.IsTrue(typeof(EmptyDbRecord).IsAbstract);
        }
    }
}
