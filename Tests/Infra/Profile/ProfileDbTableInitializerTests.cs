using Infra.Profile;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Infra.Profile
{
    [TestClass]
    public class ProfileDbTableInitializerTests :BaseTests
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            type = typeof(ProfileDbTableInitializer);
        }

        [TestMethod]
        public void InitializeTest()
        {
            Assert.Inconclusive();
        }
    }
}
