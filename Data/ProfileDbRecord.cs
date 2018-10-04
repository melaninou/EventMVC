using Core;
using Data.Common;

namespace Data
{
    public class ProfileDbRecord : BasicDbRecord
    {
        
        private string age;
        private string gender;

        
        public override string ID
        {
            get => getString(ref id, Constants.Unspecified);
            set => id = value;
        }

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
