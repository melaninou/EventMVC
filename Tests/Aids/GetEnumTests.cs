using Aids;
using Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Aids
{
    [TestClass]
    public class GetEnumTests : BaseTests
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            type = typeof(GetEnum);
        }

        [TestMethod]
        public void CountTest()
        {
            Assert.AreEqual(10, GetEnum.Count<EventType>());
            Assert.AreEqual(-1, GetEnum.Count<object>());
        }

        [TestMethod]
        public void CountByTypeTest()
        {
            Assert.AreEqual(10, GetEnum.Count(typeof(EventType)));
            Assert.AreEqual(-1, GetEnum.Count(typeof(object)));
        }

        [TestMethod]
        public void ValueByTypeTest()
        {
            Assert.AreEqual(EventType.Concert, GetEnum.Value(typeof(EventType), 0));
            Assert.AreEqual(EventType.Party, GetEnum.Value(typeof(EventType), 1));
            Assert.AreEqual(EventType.Sport, GetEnum.Value(typeof(EventType), 2));
            Assert.AreEqual(EventType.Music, GetEnum.Value(typeof(EventType), 3));
            Assert.AreEqual(EventType.Theatre, GetEnum.Value(typeof(EventType), 4));
            Assert.AreEqual(EventType.Festival, GetEnum.Value(typeof(EventType), 5));
            Assert.AreEqual(EventType.Folk, GetEnum.Value(typeof(EventType), 6));
            Assert.AreEqual(EventType.Family, GetEnum.Value(typeof(EventType), 7));
            Assert.AreEqual(EventType.Exhibition, GetEnum.Value(typeof(EventType), 8));
            Assert.AreEqual(EventType.Other, GetEnum.Value(typeof(EventType), 9));
        }

        [TestMethod]
        public void ValueTest()
        {
            Assert.AreEqual(EventType.Concert, GetEnum.Value<EventType>(0));
            Assert.AreEqual(EventType.Party, GetEnum.Value<EventType>(1));
            Assert.AreEqual(EventType.Sport, GetEnum.Value<EventType>(2));
            Assert.AreEqual(EventType.Music, GetEnum.Value<EventType>(3));
            Assert.AreEqual(EventType.Theatre, GetEnum.Value<EventType>(4));
            Assert.AreEqual(EventType.Festival, GetEnum.Value<EventType>(5));
            Assert.AreEqual(EventType.Folk, GetEnum.Value<EventType>(6));
            Assert.AreEqual(EventType.Family, GetEnum.Value<EventType>(7));
            Assert.AreEqual(EventType.Exhibition, GetEnum.Value<EventType>(8));
            Assert.AreEqual(EventType.Other, GetEnum.Value<EventType>(9));
        }
    }
}
