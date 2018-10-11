using System;
using Data.Common;
using Domain.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Domain.Common
{
    [TestClass]
    public abstract class DomainObjectTests<TObject,TRecord> :ObjectTests<TObject>
    where TObject: BasicObject<TRecord>
    where TRecord: BasicDbRecord, new()
    {
        protected TObject createdWithNullArg;
        protected Type dbRecordType;

        [TestMethod]
        public void DbRecordTest()
        {
            Assert.IsNotNull(obj.DbRecord);
            Assert.IsInstanceOfType(obj.DbRecord, dbRecordType);
        }

        [TestMethod]
        public void CanCreateWithNullArgumentTest()
        {
            Assert.IsNotNull(createdWithNullArg.DbRecord);
            Assert.IsInstanceOfType(createdWithNullArg.DbRecord, dbRecordType);
        }
    }
}
