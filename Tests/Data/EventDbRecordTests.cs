using Aids;
using Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Data
{
    [TestClass]
    public class EventDbRecordTests :ObjectTests<EventDbRecord>
    {
        protected override EventDbRecord getRandomTestObject()
        {
            return GetRandom.Object<EventDbRecord>();
        }
    }
}
