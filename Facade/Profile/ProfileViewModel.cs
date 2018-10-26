using Facade.Common;
using Core;
using Microsoft.AspNetCore.Http;

namespace Facade.Profile
{
    public class ProfileViewModel : BasicViewModel
    {
        private string age;
        public string Age
        {
            get => getString(ref age);
            set => age = value;
        }

        public ProfileGender Gender { get; set; }

        public IFormFile AvatarFile { get; set; }

        public string AvatarPath { get; set; }
    }
}
