using Data;
using Data.Comment;
using Domain.Common;
using Domain.Profile;

namespace Domain.CommentsProfiles
{
    public sealed class CommentsProfileObject : BasicObject<CommentsProfileDbRecord>
    {
        //public readonly EventObject EventObject;
        public readonly ProfileObject ProfileObject;

        public CommentsProfileObject(CommentsProfileDbRecord dDbRecord) : base(dDbRecord)
        {
            //DbRecord.Events = DbRecord.Events ?? new EventDbRecord();
            DbRecord.Profiles = DbRecord.Profiles ?? new ProfileDbRecord();

            //EventObject = new EventObject(DbRecord.Events);
            ProfileObject = new ProfileObject(DbRecord.Profiles);
        }
    }
}
