using System.Linq;
using Data;

namespace Infra
{
    public static class EventProfileDbTableInitializer
    {
       
        public static void Initialize(EventProjectDbContext c)
        {
            c.Database.EnsureCreated();
            if (c.EventsProfiles.Any()) return;
            foreach (var p in c.Profiles)
            {
                foreach (var e in c.Events)
                {
                    var r = new AttendingDbRecord
                    {
                        ProfileID = p.ID,
                        EventID = e.ID
                    };
                    c.EventsProfiles.Add(r);
                }
            }
            c.SaveChanges();
        }


    }
}
