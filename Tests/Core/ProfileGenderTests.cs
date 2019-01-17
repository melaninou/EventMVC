using Aids;
using Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Core
{
    [TestClass]
    public class ProfileGenderTests :ClassTests<ProfileGender>
    {

        [TestMethod]
        public void CountTest()
        {
            Assert.AreEqual(2, GetEnum.Count<ProfileGender>());
        }

        [TestMethod]
        public void FemaleTest() =>
            Assert.AreEqual(0, (int)ProfileGender.Female);

        [TestMethod]
        public void MaleTest() =>
            Assert.AreEqual(1, (int) ProfileGender.Male);
    }
}
