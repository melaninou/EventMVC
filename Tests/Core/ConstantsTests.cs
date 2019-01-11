using Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Core
{
    [TestClass]
    public class ConstantsTests :BaseTests
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            type = typeof(Constants);
        }
        [TestMethod]
        public void UnspecifiedTest()
        {
            Assert.IsTrue(!string.IsNullOrWhiteSpace(Constants.Unspecified.Trim()));
        }

        [TestMethod]
        public void InvalidImageFileTest()
        {
            Assert.IsTrue(!string.IsNullOrWhiteSpace(Constants.InvalidImageFile.Trim()));
        }
    }
}
