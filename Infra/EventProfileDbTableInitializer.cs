﻿using System;
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
                foreach (var r in c.Events)
                {
                    var x = new EventProfileDbRecord();
                    x.EventID = r.ID;
                    x.ProfileID = p.ID;
                    c.EventsProfiles.Add(x);
                }
            }
            c.SaveChanges();
        }



        ////todo what to initialize ???????!!!!
        //private static string add(EventProjectDbContext c, EventDbRecord db)
        //{
        //    db.ID = Guid.NewGuid().ToString();
        //    c.Events.Add(db);
        //    return db.ID;
        //}
    }
}