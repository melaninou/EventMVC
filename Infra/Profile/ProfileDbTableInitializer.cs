using System;
using System.Linq;
using Core;
using Data;

namespace Infra.Profile
{
    public static class ProfileDbTableInitializer 
    {
        public static void Initialize(EventProjectDbContext c)
        {
            c.Database.EnsureCreated(); //kas andmebaas on olemas
            if (c.Profiles.Any()) return; //kui aadresside tabelis midagi, lõpetab tegevuse
            initProfiles(c);
            c.SaveChanges();
        }
        private static void initProfiles(EventProjectDbContext c)
        {
            add(c, new ProfileDbRecord
            {  
                Name = "Iris Nael",
                Location = "Tallinn",
                Gender = ProfileGender.Female
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
