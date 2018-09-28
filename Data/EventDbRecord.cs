using System;
using System.Collections.Generic;
using System.Text;
using Core;
using Data.Common;

namespace Data
{
    public class EventDbRecord : UniqueDbRecord
    {
        private string time;
        private string type;
        private string organiser;
        private string description;

        public string Time
        {
            get => getString(ref time, Constants.Unspecified);
            set => time = value;
        }

        public string Type
        {
            get => getString(ref type, Constants.Unspecified);
            set => type = value;
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
