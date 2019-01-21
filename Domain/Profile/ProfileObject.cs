using System.Collections.Generic;
using Core;
using Data;
using Domain.Common;
using Domain.Event;

namespace Domain.Profile
{
    public sealed class ProfileObject : BasicObject<ProfileDbRecord>
    {
        private readonly List<EventObject> usedInEvents;
        private readonly List<ProfileObject> profilesInUse;
       

        public ProfileObject(ProfileDbRecord r) : base(r ?? new ProfileDbRecord())
        {
            usedInEvents = new List<EventObject>();
            profilesInUse = new List<ProfileObject>();
        }

        public IReadOnlyList<EventObject> UsedInEvents => usedInEvents.AsReadOnly();
        public IReadOnlyList<ProfileObject> ProfilesInUse => profilesInUse.AsReadOnly();

        public void UsedInEvent(EventObject eventObject)
        {
            if (eventObject is null) return;
            if (eventObject.DbRecord.ID == Constants.Unspecified) return;
            if (usedInEvents.Find(x => x.DbRecord.ID == eventObject.DbRecord.ID) != null)
                return;
            usedInEvents.Add(eventObject);
        }

        public void ProfileInUse(ProfileObject profileObject)
        {
            if (profileObject is null) return;
            if (profileObject.DbRecord.ID == Constants.Unspecified) return;
          //  if (profilesInUse.Find(x => x.DbRecord.ID == profileObject.DbRecord.ID) != null)
             //   return;
            profilesInUse.Add(profileObject);
        }
    }
}
