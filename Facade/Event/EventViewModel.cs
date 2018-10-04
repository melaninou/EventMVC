
using System;
using Core;
using Facade.Common;

namespace Facade.Event
{
    public class EventViewModel : BasicViewModel
    {
        private DateTime date;
        private string organiser;
        private string description;

        public DateTime Date
        {
            get => getValue(ref date, ref date);
            set => setValue(ref date, value);
        }

        public string Organiser
        {
            get => getString(ref organiser, Constants.Unspecified);
            set => organiser = value;
        }

        public string Description
        {
            get => getString(ref description, Constants.Unspecified);
            set => description = value;
        }
    }
}
