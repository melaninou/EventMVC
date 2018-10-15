using Core;
using Domain.Event;

namespace Facade.Event
{
    public class EventViewModelsList : PaginatedList<EventViewModel>
    {

        public EventViewModelsList(IPaginatedList<EventObject> l)
        {
            if (l is null) return;
            PageIndex = l.PageIndex;
            TotalPages = l.TotalPages;
            foreach (var e in l)
            {
                Add(EventViewModelFactory.Create(e));
            }
        }
    }
}
