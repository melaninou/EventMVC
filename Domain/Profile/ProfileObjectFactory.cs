using System;
using Core;
using Data;

namespace Domain.Profile
{
    public static class ProfileObjectFactory
    {
        public static ProfileObject Create(string id, string name, string location, 
            ProfileGender gender, DateTime birthDay, string occupation, string aboutText, string profileImage)
        {
            var o = new ProfileDbRecord
            {
                ID = id,
                Name = name,
                Location = location,
                Gender = gender,
                BirthDay = birthDay,
                AboutText = aboutText,
                Occupation = occupation,
                ProfileImage = profileImage
            };
            return new ProfileObject(o);
        }
    }
}
