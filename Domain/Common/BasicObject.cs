using System;
using System.Collections.Generic;
using System.Text;
using Core;
using Data.Common;

namespace Domain.Common
{
    public abstract class BasicObject<T> : RootObject where T : BasicDbRecord, new()
    {
        public readonly T DbRecord;

        protected BasicObject(T dbRecord)
        {
            DbRecord = dbRecord ?? new T(); //creates new object when dbRecord is null
        }
    }
}
