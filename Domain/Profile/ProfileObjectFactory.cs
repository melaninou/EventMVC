using Core;
using Data;

namespace Domain.Profile
{
    public static class ProfileObjectFactory
    {
        public static ProfileObject Create(string id, string name, string location, string age,
            ProfileGender gender)
        {
            var o = new ProfileDbRecord
            {
                ID = id,
                Name = name,
                Location = location,
                Age = age,
                Gender = gender
            };
            return new ProfileObject(o);
        }
    }
}
