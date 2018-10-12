using Aids;
using Data;
using Data.Common;
using Domain.Common;

namespace Tests.Domain.Common
{
    public class BasicObjectTests :DomainObjectTests<BasicObject<EventDbRecord>, EventDbRecord>
    {
        class testClass : BasicObject<EventDbRecord>
        {
            public testClass(EventDbRecord dbRecord) :base(dbRecord) { }
        }

        protected override BasicObject<EventDbRecord> getRandomTestObject()
        {
            createdWithNullArg = new testClass(null);
            dbRecordType = typeof(BasicDbRecord);
            return GetRandom.Object<testClass>();
        }
    }
}
