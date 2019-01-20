using Core;
using Data.Common;

namespace Domain.Common
{
    public abstract class EmptyObject<T> : RootObject where T : EmptyDbRecord, new()
    {
        public readonly T DbRecord;

        protected EmptyObject(T eventDbRecord)
        {
            DbRecord = eventDbRecord ?? new T();
        }
    }
}
