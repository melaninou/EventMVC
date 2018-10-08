using Facade.Common;
using Core;

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
    }
}
