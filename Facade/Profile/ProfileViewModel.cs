using System;
using System.ComponentModel;
using Facade.Common;
using Core;
using Microsoft.AspNetCore.Http;

namespace Facade.Profile
{
    public class ProfileViewModel : BasicViewModel
    {
    

        private DateTime birthDay;
        private string aboutText;
        private string occupation;
        private string profileImage;


        public DateTime BirthDay
        {
            get => getValue(ref birthDay, ref birthDay);
            set => setValue(ref birthDay, value);
        }



        public string Occupation
        {
            get => getString(ref occupation);
            set => occupation = value;
        }

        [DisplayName("Little bit about Me:")]
        public string AboutText
        {
            get => getString(ref aboutText);
            set => aboutText = value;
        }


        public ProfileGender Gender { get; set; }

        public string ProfileImage
        { 
            get => getString(ref profileImage);
            set => profileImage = value;
        }


}
}
