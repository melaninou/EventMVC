using Data;
using Domain.Common;
using Domain.Event;
using Domain.Profile;

namespace Domain.Attending
{
    public class AttendingObject : EmptyObject<AttendingDbRecord>
    {
        public readonly EventObject EventObject;
        public readonly ProfileObject ProfileObject;

        public AttendingObject(AttendingDbRecord dbRecord) : base(dbRecord)
        {
            DbRecord.Events = DbRecord.Events ?? new EventDbRecord();
            DbRecord.Profiles = DbRecord.Profiles ?? new ProfileDbRecord();

            EventObject = new EventObject(DbRecord.Events);
            ProfileObject = new ProfileObject(DbRecord.Profiles);
        }
    }
}
