using Aids;
using Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Core
{
    [TestClass]
    public class EventTypeTests :ClassTests<EventType>
    {
        [TestMethod]
        public void CountTest()
        {
            Assert.AreEqual(10, GetEnum.Count<EventType>());
        }

        [TestMethod]
        public void ConcertTest() =>
            Assert.AreEqual(0, (int) EventType.Concert);

        [TestMethod]
        public void PartyTest() =>
            Assert.AreEqual(1, (int)EventType.Party);

        [TestMethod]
        public void SportTest() =>
            Assert.AreEqual(2, (int)EventType.Sport);

        [TestMethod]
        public void MusicTest() =>
            Assert.AreEqual(3, (int)EventType.Music);

        [TestMethod]
        public void TheatreTest() =>
            Assert.AreEqual(4, (int)EventType.Theatre);

        [TestMethod]
        public void FestivalTest() =>
            Assert.AreEqual(5, (int)EventType.Festival);

        [TestMethod]
        public void FolkTest() =>
            Assert.AreEqual(6, (int)EventType.Folk);

        [TestMethod]
        public void FamilyTest() =>
            Assert.AreEqual(7, (int)EventType.Family);

        [TestMethod]
        public void ExhibitionTest() =>
            Assert.AreEqual(8, (int)EventType.Exhibition);

        [TestMethod]
        public void OtherTest() =>
            Assert.AreEqual(9, (int)EventType.Other);
    }
}
