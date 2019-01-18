using System;
using Core;
using Data.Common;

namespace Data
{
    public class EventDbRecord : BasicDbRecord
    {
        private DateTime date;
        private DateTime dateCreated;
        private string organizer;
        private string description;
        private string eventImage;

        public override string ID
        {
            get => getString(ref id);
            set => id = value;
        }
        public EventType Type { get; set; }
        
        public DateTime Date
        {
            get => getValue(ref date, ref date);
            set => setValue(ref date, value);
        }
 
        public string Organizer
        {
            get => getString(ref organizer);
            set => organizer = value;
        }

        public string Description
        {
            get => getString(ref description);
            set => description = value;
        }

        public string EventImage
        {
            get => getString(ref eventImage);
            set => eventImage = value;
        }

        public DateTime DateCreated
        {
            get => getValue(ref dateCreated, ref dateCreated);
            set => setValue(ref dateCreated, value);
        }
    }
}
