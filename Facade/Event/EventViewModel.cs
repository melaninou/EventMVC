﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        public EventType Type { get; set; }
       
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
        
        public string Description
        {
            get => getString(ref description);
            set => description = value;
        }

        [DisplayName("Who else is going:")]
        public List<ProfileViewModel> InProfiles { get; } = new List<ProfileViewModel>();     
    }
}
