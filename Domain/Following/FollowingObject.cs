using System;
using System.Collections.Generic;
using System.Text;
using Data;
using Domain.Common;
using Domain.Profile;

namespace Domain.Following
{
    public class FollowingObject : EmptyObject<FollowingDbRecord>
    {
        public readonly ProfileObject UserObject;
        public readonly ProfileObject FollowedUserObject;

        public FollowingObject(FollowingDbRecord dbRecord) : base(dbRecord)
        {
            DbRecord.UserProfile = DbRecord.UserProfile ?? new ProfileDbRecord();
            DbRecord.FollowedUserProfile = DbRecord.FollowedUserProfile ?? new ProfileDbRecord();
            UserObject = new ProfileObject(DbRecord.UserProfile);
            FollowedUserObject = new ProfileObject(DbRecord.FollowedUserProfile);
        }
    }
}
