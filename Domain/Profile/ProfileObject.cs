using System;
using System.Collections.Generic;
using System.Text;
using Data;
using Domain.Common;

namespace Domain.Profile
{
    public sealed class ProfileObject : BasicObject<ProfileDbRecord>
    {
        private readonly List<ProfileObject> profilesInUse;

        public ProfileObject(ProfileDbRecord r) : base(r ?? new ProfileDbRecord())
        {
            profilesInUse = new List<ProfileObject>();
        }
    }
}
