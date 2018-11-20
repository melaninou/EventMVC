

using Data;
using Domain.Event;
using Domain.Profile;

namespace Domain.Attending
{
    public static class AttendingObjectFactory
    {
        public static AttendingObject Create(EventObject eventObject, ProfileObject profileObject,
            string eventID, string userID)
        {
            var o = new AttendingDbRecord
            {
                EventID = eventID,
                ProfileID = userID,
                Events = eventObject?.DbRecord ?? new EventDbRecord(),
                Profiles = profileObject?.DbRecord ?? new ProfileDbRecord()
            };
            o.EventID = o.Events.ID;
            o.ProfileID = o.Profiles.ID;
            return new AttendingObject(o);
        }
    }
}
