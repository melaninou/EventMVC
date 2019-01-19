using System.Collections.Generic;
using Core;
using Data;

namespace Domain.Event
{
    public class EventObjectsList : PaginatedList<EventObject>
    {
        public EventObjectsList(IEnumerable<EventDbRecord> items, RepositoryPage page) : base(page)
        {
            if (items is null) return;
            foreach (var dbRecord in items)
            {
                Add(new EventObject(dbRecord));
            }
        }
    }
}
