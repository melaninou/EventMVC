using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Facade.Common;
using Core;

namespace Facade.Profile
{
    public class ProfileViewModel : BasicViewModel
    {
    
        private DateTime birthDay;
        private string aboutText;
        private string occupation;
        private string profileImage;

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [Required]
        public DateTime BirthDay
        {
            get => getValue(ref birthDay, ref birthDay);
            set => setValue(ref birthDay, value);
        }

        [Required]
        public string Occupation
        {
            get => getString(ref occupation);
            set => occupation = value;
        }

        [Required]
        [DisplayName("Little bit about Me:")]
        public string AboutText
        {
            get => getString(ref aboutText);
            set => aboutText = value;
        }

        public ProfileGender Gender { get; set; }

        [Required]
        public string ProfileImage
        { 
            get => getString(ref profileImage);
            set => profileImage = value;
        }
    }
}
