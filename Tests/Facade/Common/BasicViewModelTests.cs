using Aids;
using Facade.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Facade.Common
{
    [TestClass]
    public class BasicViewModelTests :ViewModelTests<BasicViewModel,BasicViewModel>
    {
        class testClass : BasicViewModel { }

        protected override BasicViewModel getRandomTestObject()
        {
            return GetRandom.Object<testClass>();
        }

        [TestMethod]
        public void NameTest()
        {
            testReadWriteProperty(() => obj.Name, x => obj.Name = x);
        }

        [TestMethod]
        public void IDTest()
        {
            testReadWriteProperty(() => obj.ID, x => obj.ID = x);
        }


        [TestMethod]
        public void LocationTest()
        {
            testReadWriteProperty(() => obj.Location, x => obj.Location = x);
        }
    }
}
