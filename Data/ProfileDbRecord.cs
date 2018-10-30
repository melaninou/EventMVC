using System;
using Core;
using Data.Common;

namespace Data
{
    public class ProfileDbRecord : BasicDbRecord
    {
        private string profileImage;
        private DateTime birthDay;
        private string aboutText;
        private string occupation;
        
        public ProfileGender Gender { get; set; }

        public DateTime BirthDay
        {
            get => getValue(ref birthDay, ref birthDay);
            set => setValue(ref birthDay, value);
        }

        public string ProfileImage
        {
            get => getString(ref profileImage);
            set => profileImage = value;
        }

        public string AboutText
        {
            get => getString(ref aboutText);
            set => aboutText = value;
        }

        public string Occupation
        {
            get => getString(ref occupation);
            set => occupation = value;
        }
    }  
}
