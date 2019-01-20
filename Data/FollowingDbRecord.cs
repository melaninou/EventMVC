using System;
using System.Collections.Generic;
using System.Text;
using Data.Common;

namespace Data
{
    public class FollowingDbRecord : EmptyDbRecord
    {
        private string userID;
        private string followedUserID;

        public string UserID
        {
            get => getString(ref userID);
            set => userID = value;
        }
        public string FollowedUserID
        {
            get => getString(ref followedUserID);
            set => followedUserID = value;
        }

        public virtual ProfileDbRecord UserProfile { get; set; }
        public virtual ProfileDbRecord FollowedUserProfile { get; set; }
    }
}
