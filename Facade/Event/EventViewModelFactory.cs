﻿using Domain.Event;

namespace Facade.Event
{
    public static class EventViewModelFactory
    {
        public static EventViewModel Create(EventObject o)
        {
            var v = new EventViewModel
            {
                Name = o?.DbRecord.Name,
                ID = o?.DbRecord.ID,
                Location = o?.DbRecord.Location,
                Type = o.DbRecord.Type,
                Date = o.DbRecord.Date,
                Description = o?.DbRecord.Description,
                Organiser = o?.DbRecord.Organiser
            };
            if (o is null) return v;
            
            return v;
        }
    }
}