using System;
using Core;
using Data.Common;

namespace Data
{
    public class EventDbRecord : BasicDbRecord
    {
        private DateTime date;
        private string organiser;
        private string description;
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
 
        public string Organiser
        {
            get => getString(ref organiser);
            set => organiser = value;
        }

        public string Description
        {
            get => getString(ref description);
            set => description = value;
        }
    }
}
