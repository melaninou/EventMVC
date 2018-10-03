using Core;

namespace Data
{
    public class EventProfileDbRecord  : RootObject
    {
        private string profileID;
        private string eventID;

        public string ProfileID
        {
            get => getString(ref profileID);
            set => profileID = value;
        }
        public string EventID
        {
            get => getString(ref eventID);
            set => eventID = value;
        }
        public virtual EventDbRecord Events { get; set; }
        public virtual ProfileDbRecord Profiles { get; set; }
    }
}
