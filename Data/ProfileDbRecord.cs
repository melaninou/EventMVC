using Core;

namespace Data
{
    public class ProfileDbRecord : RootObject
    {
        private string id;
        private string name;
        private string age;
        private string location;
        private string gender;

        //TODO think override
        
        public string ID
        {
            //todo id -> protected in another class ? 
            get => getString(ref id, Name);
            set => id = value;
        }

        public string Name
        {
            get => getString(ref name, Name);
            set => name = value;
        }

        public string Age
        {
            get => getString(ref age, Constants.Unspecified);
            set => age = value;
        }

        public string Location
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
