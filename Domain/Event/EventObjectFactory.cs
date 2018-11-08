﻿using System;
using Core;
using Data;

namespace Domain.Event
{
    public static class EventObjectFactory
    {
        public static EventObject Create(string id, string name,
            string location, DateTime date, EventType type,
            string organiser, string description, string eventImage)
        {
            var o = new EventDbRecord
            {
                ID = id,
                Name = name,
                Location = location,
                Date = date,
                Type = type,
                Organizer = organiser,
                Description = description,
                EventImage = eventImage
            };
            return new EventObject(o);
        }
    }
}
