using Data;
using Domain.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Domain.Common
{
    [TestClass]
    public class EmptyObjectTests
    {

        class testClass : EmptyObject<AttendingDbRecord>
        {
            public testClass(AttendingDbRecord dbRecord) : base(dbRecord)
            {
            }
        }
    }
}
