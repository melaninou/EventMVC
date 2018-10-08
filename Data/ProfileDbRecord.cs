using Core;
using Data.Common;

namespace Data
{
    public class ProfileDbRecord : BasicDbRecord
    {      
        private string age;
        
        public override string ID
        {
            get => getString(ref id);
            set => id = value;
        }

        public string Age
        {
            get => getString(ref age);
            set => age = value;
        }
        public ProfileGender Gender { get; set; }
    }  
}
