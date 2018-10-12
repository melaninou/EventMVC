using Infra.Profile;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Infra.Profile
{
    [TestClass]
    public class ProfileObjectsRepositoryTests :BaseTests
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            type = typeof(ProfileObjectsRepository);
        }

        [TestMethod]
        public void CanCreate()
        {
            Assert.IsNotNull(new ProfileObjectsRepository(null));
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
