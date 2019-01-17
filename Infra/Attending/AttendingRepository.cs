using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core;
using Data;
using Domain.Attending;
using Domain.Event;
using Domain.Profile;
using Microsoft.EntityFrameworkCore;
using Open.Infra;

namespace Infra.Attending
{
    public class AttendingRepository : ObjectsRepository<EventObject, EventDbRecord>, IAttendingObjectsRepository
    {
        internal readonly DbSet<AttendingDbRecord> dbSet;
        internal readonly DbSet<EventDbRecord> eventDbSet;
        private readonly DbContext db;
        private IEventObjectsRepository _eventObjectsRepository;

        public AttendingRepository(EventProjectDbContext c) : base(c?.Events, c)
        {
            db = c;
            dbSet = c?.EventsProfiles;
            eventDbSet = c?.Events;
        }

        public Task<AttendingObject> GetObject(string id)
        {
            throw new NotImplementedException();
        }

        protected internal override EventObject createObject(EventDbRecord r)
        {
            return new EventObject(r);
        }

        protected internal override PaginatedList<EventObject> createList(List<EventDbRecord> l, RepositoryPage p)
        {
            return new EventObjectsList(l, p);
        }

        public async Task<AttendingObject> GetObject(string eventID, string userID)
        {
            //if (eventID == null || userID == null) return null;
            var o = await dbSet.FirstOrDefaultAsync(x => x.EventID == eventID && x.ProfileID == userID);
            return new AttendingObject(o);
        }

        public async Task<List<EventObject>> GetUserEventsList(string userID)
        {
            var userEvents = dbSet.Where(p => p.ProfileID == userID);

            var list = userEvents.Select(s=> new {s.EventID}).ToList();
            var eventDbRecordsList = new List<EventDbRecord>();
            foreach (var value in list)
            {
                string test = value.ToString();
                int lastIndexOfTest = test.Length - 1;
                string realTestString = test.Substring(12, lastIndexOfTest - 1 - 12);

                var oneEventObject = await eventDbSet.AsNoTracking().SingleOrDefaultAsync(x => x.ID == realTestString);
                eventDbRecordsList.Add(oneEventObject);
            }
            var count = eventDbRecordsList.Count();
            var pp = new RepositoryPage(count, PageIndex, PageSize);
            var items = eventDbRecordsList.Skip(pp.FirstItemIndex).Take(pp.PageSize).ToList();
            return createList(eventDbRecordsList, pp);
        }

        public async Task AddObject(AttendingObject o)
        {
            var r = o.DbRecord;
            r.Events = null;
            r.Profiles = null;
            dbSet.Add(r);
            await db.SaveChangesAsync();
        }

        public async Task UpdateObject(AttendingObject o)
        {
            dbSet.Update(o.DbRecord);
            await db.SaveChangesAsync();
        }

        public async Task DeleteObject(AttendingObject o)
        {
            var r = o.DbRecord;
            r.Profiles = null;
            r.Events = null;
            dbSet.Remove(r);
            await db.SaveChangesAsync();
        }

        public async Task LoadProfiles(EventObject eventObject)
        {
            if (eventObject is null) return;
            var eventID = eventObject.DbRecord.ID ?? string.Empty;
            var profiles = await dbSet.Include(x => x.Profiles).
                Where(x => x.EventID == eventID).AsNoTracking()
                .ToListAsync();
            foreach (var p in profiles)
            {
                eventObject.ProfileInUse(new ProfileObject(p.Profiles));
            }
        }

        public async Task RemoveListObjects(EventObject eventObject)
        {

            if (eventObject is null) return;
            var eventID = eventObject.DbRecord.ID ?? string.Empty;
            var profiles = await dbSet.Include(x => x.Profiles).
                Where(x => x.EventID == eventID).AsNoTracking()
                .ToListAsync();
            if (profiles.Count == 0) return;
            foreach (var p in profiles)
            {
                dbSet.Remove(p);
            }
            profiles.Clear();
            await db.SaveChangesAsync();
        }
        public async Task LoadEvents(ProfileObject profileObject)
        {
            if (profileObject is null) return;
            var userID = profileObject.DbRecord.ID ?? string.Empty;
            var events = await dbSet.Include(x => x.Events).
                Where(x => x.ProfileID == userID).AsNoTracking()
                .ToListAsync();
            foreach (var e in events)
            {
                profileObject.UsedInEvent(new EventObject(e.Events));
            }
        }

        public async Task<object> FindObject(string id, string userID)
        {
            var item = dbSet.Find(id, userID);
            if (item != null) return item;
            else return null;
        }
    }
}
