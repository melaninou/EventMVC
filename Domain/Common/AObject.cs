using System;
using System.Collections.Generic;
using System.Text;
using Core;
using Data.Common;

namespace Domain.Common
{
    public abstract class AObject<T> : RootObject where T : EmptyDbReord, new()
    {
        public readonly T DbRecord;

        protected AObject(T dbRecord)
        {
            DbRecord = dbRecord ?? new T();
        }
    }
}
