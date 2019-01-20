using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core;
using Data;
using Data.Comment;
using Domain.Attending;
using Domain.Comment;
using Domain.CommentProfile;
using Domain.Profile;
using Microsoft.EntityFrameworkCore;
using Open.Infra;

namespace Infra.Comment
{
   public class CommentProfileRepository : ObjectsRepository<CommentObject, CommentDbRecord>, ICommentProfileObjectsRepository
   {
        internal readonly DbSet<CommentProfileDbRecord> dbSet;
       private readonly DbContext db;

       public CommentProfileRepository(EventProjectDbContext c) : base(c?.Comments, c)
       {
           db = c;
           dbSet = c?.CommentProfile;
       }
       public async Task AddObject(CommentProfileObject o)
       {
           var r = o.DbRecord;
           r.Comments = null;
           r.Profiles = null;
           dbSet.Add(r);
           await db.SaveChangesAsync();
       }
       public async Task UpdateObject(CommentProfileObject o)
       {
           dbSet.Update(o.DbRecord);
           await db.SaveChangesAsync();
       }

       public async Task DeleteObject(CommentProfileObject o)
       {
           var r = o.DbRecord;
           r.Comments = null;
           r.Profiles = null;
           dbSet.Remove(r);
           await db.SaveChangesAsync();
       }
       public async Task<CommentProfileObject> GetObject(string profileID, string commentID)
       {
           //if (eventID == null || userID == null) return null;
           var o = await dbSet.FirstOrDefaultAsync(x => x.ProfileID == profileID && x.CommentID == commentID);
           return new CommentProfileObject(o);
       }

       public async Task<CommentProfileObject> GetObject(string commentID)
       {
           var o = await dbSet.FirstOrDefaultAsync(x => x.CommentID == commentID);
           return new CommentProfileObject(o);
       }
        public async Task<string> GetObjectString(string commentID)
       {
           var o = await dbSet.FirstOrDefaultAsync(x =>  x.CommentID == commentID);
           var profile = o.ProfileID; 
           return profile;
        }

       protected internal override CommentObject createObject(CommentDbRecord r)
       {
           return new CommentObject(r);
       }
       protected internal override PaginatedList<CommentObject> createList(List<CommentDbRecord> l, RepositoryPage p)
       {
           return new CommentObjectsList(l, p);
       }

    }
}
