using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core;
using Data;
using Domain.Event;
using Microsoft.EntityFrameworkCore;
using Open.Infra;

namespace Infra.Event
{
    public class EventObjectsRepository : ObjectsRepository<EventObject, EventDbRecord>,
        IEventObjectsRepository
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

        public async Task<List<EventObject>> GetOrganizerEventsList(string userID)
        {
            var organizerEvents = dbSet.Where(p => p.Organizer == userID);

            var list = organizerEvents.Select(s => new { s.ID }).ToList();
            var eventDbRecordsList = new List<EventDbRecord>();
            foreach (var value in list)
            {
                string eventIDLongVersion = value.ToString();
                int lastIndexOfidLongVersion = eventIDLongVersion.Length - 1;
                string idRightVersion = eventIDLongVersion.Substring(7, lastIndexOfidLongVersion - 1 - 7);


                var oneEventObject = await dbSet.AsNoTracking().SingleOrDefaultAsync(x => x.ID == idRightVersion);
                eventDbRecordsList.Add(oneEventObject);
            }
            var count = eventDbRecordsList.Count();
            var pp = new RepositoryPage(count, PageIndex, PageSize);
            var items = eventDbRecordsList.Skip(pp.FirstItemIndex).Take(pp.PageSize).ToList();
            return createList(eventDbRecordsList, pp);
        }


        /*public async Task<PaginatedList<EventObject>> GetEventList()
        {
            var events = getSorted().Where(s => s is EventDbRecord && s.Contains(SearchString))
                .AsNoTracking();
            var count = await events.CountAsync();
            var p = new RepositoryPage(count, PageIndex, PageSize);
            var items = await events.Skip(p.FirstItemIndex).Take(p.PageSize).ToListAsync();
            return createList(items, p);
        }*/

        private IQueryable<EventDbRecord> getSorted()
        {
            if (SortFunction is null) return getSet();
            return SortOrder == SortOrder.Descending
                ? getSet().OrderByDescending(x => SortFunction(x))
                : getSet().OrderBy(x => SortFunction(x));
        }
        private IQueryable<EventDbRecord> getSet()
        {
            return from s in dbSet select s;
        }
    }
}
