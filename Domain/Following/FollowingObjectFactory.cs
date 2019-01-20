using System;
using System.Collections.Generic;
using System.Text;
using Data;
using Domain.Attending;
using Domain.Event;
using Domain.Profile;

namespace Domain.Following
{
    public static class FollowingObjectFactory
    {
        public static FollowingObject Create(ProfileObject userProfileObject, ProfileObject followedUserProfileObject,
            string userID, string followedUserID)
        {
            var o = new FollowingDbRecord
            {
                FollowedUserID = followedUserID,
                UserID = userID,
                UserProfile = userProfileObject?.DbRecord ?? new ProfileDbRecord(),
                FollowedUserProfile = followedUserProfileObject?.DbRecord ?? new ProfileDbRecord()
            };
            o.UserID = o.UserProfile.ID;
            o.FollowedUserID = o.FollowedUserProfile.ID;
            return new FollowingObject(o);
        }
    }
}
