using System;
using Core;
using Data.Common;

namespace Data
{
    public class EventDbRecord : BasicDbRecord
    {
        private DateTime date;
        private DateTime dateToday = DateTime.Today;

        public EventType Type { get; set; }

        private string organiser;
        private string description;

        public DateTime Date
        {
            get => getValue(ref dateToday, ref date);
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
