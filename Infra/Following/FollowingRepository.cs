using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data;
using Domain.Event;
using Domain.Following;
using Domain.Profile;
using Microsoft.EntityFrameworkCore;
using Open.Infra;
using System.Threading.Tasks;
using Core;

namespace Infra.Following
{
    public class FollowingRepository : ObjectsRepository<ProfileObject, ProfileDbRecord>, IFollowingObjectsRepository
    {
        internal readonly DbSet<FollowingDbRecord> dbSet;
        internal readonly DbSet<ProfileDbRecord> profileDbSet;
        private readonly DbContext db;
        private IProfileObjectsRepository _profileObjectsRepository;

        public FollowingRepository(EventProjectDbContext c) : base(c?.Profiles, c)
        {
            db = c;
            dbSet = c?.Followings;
            profileDbSet = c?.Profiles;
        }

        public async Task<FollowingObject> GetObject(string userID, string followedUserID)
        {
            var o = await dbSet.FirstOrDefaultAsync(x => x.UserID == userID && x.FollowedUserID == followedUserID);
            return new FollowingObject(o);
        }

        public async Task<object> FindObject(string id, string userID)
        {
            var item = dbSet.Find(userID, id);
            if (item != null) return item;
            else return null;
        }

        public async Task AddObject(FollowingObject o)
        {
            var r = o.DbRecord;
            r.UserProfile = null;
            r.FollowedUserProfile = null;
            dbSet.Add(r);
            await db.SaveChangesAsync();
        }

        public async Task UpdateObject(FollowingObject o)
        {
            dbSet.Update(o.DbRecord);
            await db.SaveChangesAsync();
        }

        public async Task DeleteObject(FollowingObject o)
        {
            var r = o.DbRecord;
            r.UserProfile = null;
            r.FollowedUserProfile = null;
            dbSet.Remove(r);
            await db.SaveChangesAsync();
        }

        public Task<FollowingObject> GetObject(string id)
        {
            throw new NotImplementedException();
        }

        protected internal override ProfileObject createObject(ProfileDbRecord r)
        {
            return new ProfileObject(r);
        }

        protected internal override PaginatedList<ProfileObject> createList(List<ProfileDbRecord> l, RepositoryPage p)
        {
            return new ProfileObjectsList(l, p);
        }

        public async Task LoadFollowers(ProfileObject userObject)
        {
            if (userObject is null) return;
            var userID = userObject.DbRecord.ID ?? string.Empty;
            var profiles = await dbSet.Include(x => x.FollowedUserProfile).
                Where(x => x.UserID == userID).AsNoTracking()
                .ToListAsync();
            foreach (var p in profiles)
            {
                userObject.ProfileInUse(new ProfileObject(p.FollowedUserProfile));
            }
        }
    }
}
