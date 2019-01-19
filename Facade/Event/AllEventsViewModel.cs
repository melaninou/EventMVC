using System.Collections.Generic;
using Core;
using Domain.Event;

namespace Facade.Event
{
    public class AllEventsViewModel
    {
        public IPaginatedList<EventObject> AllEventViewModel { get; set; }
        public List<EventObject> MyEventsViewModel { get; set; }
        public List<EventObject> MyOrganizedEventsViewModel { get; set; }
    }
}
