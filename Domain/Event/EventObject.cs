using System;
using System.Collections.Generic;
using System.Text;
using Data;
using Domain.Common;
using Domain.Profile;

namespace Domain.Event
{
   public sealed class EventObject : BasicObject<EventDbRecord>
   {
       private readonly List<EventObject> eventsInUse;

       public EventObject(EventDbRecord r) : base(r ?? new EventDbRecord())
       {
           eventsInUse = new List<EventObject>();
       }
   }
}
