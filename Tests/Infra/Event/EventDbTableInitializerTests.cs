using Infra.Event;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Infra.Event
{
    [TestClass]
    public class EventDbTableInitializerTests :BaseTests
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            type = typeof(EventDbTableInitializer);
        }

        [TestMethod]
        public void InitializeTest()
        {
            Assert.Inconclusive();
        }
    }
}
