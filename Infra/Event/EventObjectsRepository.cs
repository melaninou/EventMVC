using System;
using System.Collections.Generic;
using System.Text;
using Core;
using Data;
using Domain.Event;
using Open.Infra;

namespace Infra.Event
{
    public class EventObjectsRepository : ObjectsRepository<EventObject, EventDbRecord>, IEventObjectsRepository
    {
        public EventObjectsRepository(EventProjectDbContext c) : base(c?.Events, c)
        { }

        protected internal override EventObject createObject(EventDbRecord r)
        {
            return new EventObject(r);
        }

        protected internal override PaginatedList<EventObject> createList(List<EventDbRecord> l, RepositoryPage p)
        {
            return new EventObjectsList(l, p);
        }
    }
}
