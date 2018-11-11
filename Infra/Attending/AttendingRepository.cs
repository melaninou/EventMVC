﻿using System;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Domain.Attending;
using Domain.Event;
using Domain.Profile;
using Microsoft.EntityFrameworkCore;

namespace Infra.Attending
{
    public class AttendingRepository : IAttendingObjectsRepository
    {
        internal readonly DbSet<AttendingDbRecord> dbSet;
        private readonly DbContext db;

        public AttendingRepository(EventProjectDbContext c)
        {
            db = c;
            dbSet = c?.EventsProfiles;
        }

        public Task<AttendingObject> GetObject(string id)
        {
            throw new NotImplementedException();
        }
        
        public async Task<AttendingObject> GetObject(string eventID, string userID)
        {
            //if (eventID == null || userID == null) return null;
            var o = await dbSet.FirstOrDefaultAsync(x => x.EventID == eventID && x.ProfileID == userID);
            return new AttendingObject(o);
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
