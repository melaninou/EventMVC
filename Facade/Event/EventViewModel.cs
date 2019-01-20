using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Core;
using Facade.Common;
using Facade.Profile;

namespace Facade.Event
{
    public class EventViewModel : BasicViewModel
    {
        private DateTime date;
        private string organiser;
        private string description;
        private string eventImage;

        [Required]
        public EventType Type { get; set; }

        [Required]
        public DateTime Date
        {
            get => getValue(ref date, ref date);
            set => setValue(ref date, value);
        }
        

        public string Organizer
        {
            get => getString(ref organiser);
            set => organiser = value;
        }
        
        [Required]
        public string Description
        {
            get => getString(ref description);
            set => description = value;
        }

        [Required]
        public string EventImage
        {
            get => getString(ref eventImage);
            set => eventImage = value;
        }

        [DisplayName("Who is going:")]
        public List<ProfileViewModel> InProfiles { get; } = new List<ProfileViewModel>();     
    }
}
