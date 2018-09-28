using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data;

namespace Infra
{
    public static class EventProfileDbTableInitializer
    {
        public static void Initialize(EventProjectDbContext c)
        {
            c.Database.EnsureCreated();
            if (c.EventsProfiles.Any()) return;
            c.SaveChanges();
        }
        //todo what to initialize ???????!!!!
        private static string add(EventProjectDbContext c, EventDbRecord db)
        {
            db.ID = Guid.NewGuid().ToString();
            c.Events.Add(db);
            return db.ID;
        }
    }
}
