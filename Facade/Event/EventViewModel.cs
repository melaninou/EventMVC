using System;
using System.ComponentModel.DataAnnotations;
using Facade.Common;

namespace Facade.Event
{
    public class EventViewModel : BasicViewModel
    {
        private DateTime date;
        private DateTime dateToday = DateTime.Today;
        private string organiser;
        private string description;

        [Required]
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
