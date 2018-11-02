using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core;
using Data;
using Domain.Event;
using Microsoft.EntityFrameworkCore;
using Open.Infra;

namespace Infra.Event
{
    public class EventObjectsRepository : ObjectsRepository<EventObject, EventDbRecord>, IEventObjectsRepository
    {
        private readonly DbSet<EventDbRecord> dbSet;
        public EventObjectsRepository(EventProjectDbContext c) : base(c?.Events, c)
        {
            dbSet = c?.Events;
        }

        protected internal override EventObject createObject(EventDbRecord r)
        {
            return new EventObject(r);
        }

        protected internal override PaginatedList<EventObject> createList(List<EventDbRecord> l, RepositoryPage p)
        {
            return new EventObjectsList(l, p);
        }

        public Task<PaginatedList<EventObject>> GetEventList()
        {
            throw new NotImplementedException();
        }
    }
}
