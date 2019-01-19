using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Data;
using Data.Comment;
using Domain.Attending;
using Domain.Comment;
using Microsoft.EntityFrameworkCore;

namespace Infra.Comment
{
   public class CommentProfilesObjectsRepository : ICommentProfilesObjectsRepository
   {
       internal readonly DbSet<CommentsProfileDbRecord> dbSet;
       private readonly DbContext db;

       public CommentProfilesObjectsRepository(EventProjectDbContext c)
       {
           db = c;
           dbSet = c?.CommentsProfile;
       }

       public async Task<CommentsProfileObject> GetObject(string id)
       {
           throw new NotImplementedException();
       }

       public async Task<CommentsProfileObject> GetObject(string eventID, string userID)
       {
           //if (eventID == null || userID == null) return null;
           var o = await dbSet.FirstOrDefaultAsync(x => /*x.EventID == eventID && */x.ProfileID == userID);
           return new CommentsProfileObject(o);
       }
       public async Task AddObject(CommentsProfileObject o)
       {
           var r = o.DbRecord;
           //r.Events = null;
           r.Profiles = null;
           dbSet.Add(r);
           await db.SaveChangesAsync();
       }
       public async Task UpdateObject(CommentsProfileObject o)
       {
           dbSet.Update(o.DbRecord);
           await db.SaveChangesAsync();
       }

       public async Task DeleteObject(CommentsProfileObject o)
       {
           var r = o.DbRecord;
           r.Profiles = null;
           //r.Events = null;
           dbSet.Remove(r);
           await db.SaveChangesAsync();
       }

    }
}
