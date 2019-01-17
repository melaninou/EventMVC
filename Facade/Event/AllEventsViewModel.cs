using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core;
using Data;
using Domain.Attending;
using Domain.Event;

namespace Facade.Event
{
    public class AllEventsViewModel
    {
        public IPaginatedList<EventObject> AllEventViewModel { get; set; }
        public List<EventObject> MyEventsViewModel { get; set; }
    }
}
