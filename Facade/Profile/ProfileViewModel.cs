using System;
using System.Collections.Generic;
using System.Text;
using Facade.Common;
using Core;

namespace Facade.Profile
{
    public class ProfileViewModel : BasicViewModel
    {
        private string age;
        private string gender;
        public string Age
        {
            get => getString(ref age, Constants.Unspecified);
            set => age = value;
        }

        public string Gender
        {
            get => getString(ref gender, Constants.Unspecified);
            set => gender = value;
        }
    }
}
