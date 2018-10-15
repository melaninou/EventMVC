using Infra.Event;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Infra.Event
{
    [TestClass]
    public class EventObjectsRepositoryTests :BaseTests
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            type = typeof(EventObjectsRepository);
        }

        [TestMethod]
        public void CanCreate()
        {
            Assert.IsNotNull(new EventObjectsRepository(null));
        }

        [TestMethod]
        public void GetObjectsListTest()
        {
            Assert.Inconclusive();
        }


        [TestMethod]
        public void IsInitializedTest()
        {
            Assert.Inconclusive();
        }
    }
}
