using System.Collections.Generic;
using System.Linq;
using Core;
using Domain.Event;

namespace Facade.Event
{
    public class EventViewModelsList : PaginatedList<EventViewModel>
    {

        public EventViewModelsList(IPaginatedList<EventObject> l, string sortOrder = null)
        {
            if (l is null) return;
            PageIndex = l.PageIndex;
            TotalPages = l.TotalPages;
            var newEvent = new List<EventViewModel>();
            IOrderedEnumerable<EventViewModel> ordered;
            foreach (var e in l)
            {
                Add(EventViewModelFactory.Create(e));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    ordered = newEvent.OrderByDescending(s => s.Name);
                    break;
                case "id":
                    ordered = newEvent.OrderByDescending(s => s.ID);
                    break;
                case "id_desc":
                    ordered = newEvent.OrderBy(s => s.ID);
                    break;
                case "date":
                    ordered = newEvent.OrderByDescending(s => s.Date);
                    break;
                case "date_desc":
                    ordered = newEvent.OrderBy(s => s.Date);
                    break;
                case "location":
                    ordered = newEvent.OrderBy(s => s.Location);
                    break;
                case "location_desc":
                    ordered = newEvent.OrderByDescending(s => s.Location);
                    break;
                case "organizer":
                    ordered = newEvent.OrderBy(s => s.Organizer);
                    break;
                case "organizer_desc":
                    ordered = newEvent.OrderByDescending(s => s.Organizer);
                    break;
                default:
                    ordered = newEvent.OrderBy(s => s.Name);
                    break;
            }
            AddRange(ordered);
        }
    }
}
