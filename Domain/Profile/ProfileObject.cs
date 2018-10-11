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

        public ProfileObject(ProfileDbRecord r) : base(r ?? new ProfileDbRecord())
        {
            usedInEvents = new List<EventObject>();
        }

        public IReadOnlyList<EventObject> UsedInEvents => usedInEvents.AsReadOnly();

        public void UsedInEvent(EventObject eventObject)
        {
            if (eventObject is null) return;
            if (eventObject.DbRecord.ID == Constants.Unspecified) return;
            if (usedInEvents.Find(x => x.DbRecord.ID == eventObject.DbRecord.ID) != null)
                return;
            usedInEvents.Add(eventObject);
        }
    }
}
