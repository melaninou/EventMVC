using Domain.Event;
using Facade.Profile;

namespace Facade.Event
{
    public static class EventViewModelFactory
    {
        public static EventViewModel Create(EventObject o)
        {
            var v = new EventViewModel
            {
                Name = o?.DbRecord.Name,
                ID = o?.DbRecord.ID,
                Location = o?.DbRecord.Location,
                Type = o.DbRecord.Type,
                Date = o.DbRecord.Date,
                Description = o?.DbRecord.Description,
                Organizer = o?.DbRecord.Organizer,
                EventImage = o?.DbRecord.EventImage
            };
            if (o is null) return v;
            foreach (var p in o.ProfilesInUse )
            {
                var profile = ProfileViewModelFactory.Create(p);
                v.InProfiles.Add(profile);
            }
            return v;
        }
    }
}
