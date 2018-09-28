using Core;
using Data.Common;

namespace Data
{
    public class ProfileDbRecord : UniqueDbRecord
    {
        
        private string age;
        private string gender;

        
        public override string ID
        {
            get => getString(ref id, Constants.Unspecified);
            set => id = value;
        }

        public override string Name
        {
            get => getString(ref name, Constants.Unspecified);
            set => name = value;
        }

        public string Age
        {
            get => getString(ref age, Constants.Unspecified);
            set => age = value;
        }

        public override string Location
        {
            get => getString(ref location, Constants.Unspecified);
            set => location = value;
        }

        public string Gender
        {
            get => getString(ref gender, Constants.Unspecified);
            set => gender = value;
        }
   
    }  
}
