using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data;

namespace Infra
{
    public static class ProfileDbTableInitializer
    {
        public static void Initialize(EventProjectDbContext c)
        {
            c.Database.EnsureCreated();
            if (c.Profiles.Any()) return;
            initProfiles(c);


            c.SaveChanges();
        }

        private static void initProfiles(EventProjectDbContext c)
        {
            add(c, new ProfileDbRecord
            {
                ID = "123abc",
                Name = "Iris Nael",
                Age = "20",
                Location = "Tallinn",
                Gender = "Female"
            });

        }

        private static string add(EventProjectDbContext c, ProfileDbRecord profile) //unikaalse ID genereerimine
        {
            profile.ID = Guid.NewGuid().ToString();
            c.Profiles.Add(profile); //lisab andmebaasi
            return profile.ID;
        }
    }
}
