﻿using System;
using System.Collections;
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
        private DateTime dateToday = DateTime.Today;
        private string organiser;
        private string description;
        public EventType Type { get; set; }
       
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

        public List<ProfileViewModel> InProfiles { get; } = new List<ProfileViewModel>();

       
    }
}
