using System.Collections.Generic;
using Core;
using Domain.Event;

namespace Facade.Event
{
    public class EventViewModelsList : PaginatedList<EventViewModel>
    {

        public EventViewModelsList(IPaginatedList<EventObject> l)
        {
            if (l is null) return;
            var events = new List<EventViewModel>();
            foreach (var e in l) { events.Add(EventViewModelFactory.Create(e)); }
        }
    }
}
