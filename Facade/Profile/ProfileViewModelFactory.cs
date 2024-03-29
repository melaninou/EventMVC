﻿using Domain.Profile;

namespace Facade.Profile
{
    public static class ProfileViewModelFactory
    {
        public static ProfileViewModel Create(ProfileObject o)
        {
            var v = new ProfileViewModel
            {
                Name = o?.DbRecord.Name,
                ID = o?.DbRecord.ID,
                Location = o?.DbRecord.Location,
                Gender = o.DbRecord.Gender,
                BirthDay = o.DbRecord.BirthDay, 
                AboutText = o?.DbRecord.AboutText,
                Occupation = o?.DbRecord.Occupation,
                ProfileImage = o?.DbRecord.ProfileImage

            };
            if (o is null) return v;
            foreach (var p in o.ProfilesInUse)
            {
                var profile = ProfileViewModelFactory.Create(p);
                v.InProfiles.Add(profile);
            }
            return v;
        }
    }
}
