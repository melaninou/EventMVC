using Aids;
using Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Data
{
    public class EventDbRecordTests :ObjectTests<EventDbRecord>
    {
        protected override EventDbRecord getRandomTestObject()
        {
            return GetRandom.Object<EventDbRecord>();
        }

        [TestMethod]
        public void IDTest()
        {
            testReadWriteProperty(() => obj.ID, x => obj.ID = x);
            testNullEmptyAndWhitespaceCases(() => obj.ID, x => obj.ID = x, () => obj.ID);
        }
    }
}
