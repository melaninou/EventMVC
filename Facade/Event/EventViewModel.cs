using System;
using System.ComponentModel.DataAnnotations;
using Core;
using Facade.Common;

namespace Facade.Event
{
    public class EventViewModel : BasicViewModel
    {
        private DateTime date;
        private DateTime dateToday = DateTime.Today;
        private string organiser;
        private string description;
        public EventType Type { get; set; }
        [Required]
        public DateTime Date
        {
            get => getValue(ref date, ref dateToday);
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
