using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Comment;
using Domain.Event;
using Domain.Profile;
using System.Threading.Tasks;
using Core;
using Data.Comment;
using Domain.CommentsProfiles;
using Microsoft.EntityFrameworkCore;
using Open.Infra;

namespace Infra.Comment
{
    public class CommentRepository : ObjectsRepository<CommentsProfileObject, CommentsProfileDbRecord>, ICommentObjectsRepository
    {
        internal readonly DbSet<CommentDbRecord> dbSet;
        internal readonly DbSet<CommentsProfileDbRecord> fullCommentDbSet;
        private readonly DbContext db;

        public CommentRepository(EventProjectDbContext c) : base(c?.CommentsProfile, c)
        {
            db = c;
            dbSet = c?.Comment;
            fullCommentDbSet = c?.CommentsProfile;
        }
        protected internal override CommentsProfileObject createObject(CommentsProfileDbRecord r)
        {
            return new CommentsProfileObject(r);
        }
        protected internal override PaginatedList<CommentsProfileObject> createList(List<CommentsProfileDbRecord> l, RepositoryPage p)
        {
            return new CommentsProfileObjectsList(l, p);
        }
        public Task<CommentObject> GetObject(string id)
        {
            throw new NotImplementedException();
        }
        public async Task<CommentObject> GetObject(string eventID, string commentID)
        {
            //if (eventID == null || userID == null) return null;
            var o = await dbSet.FirstOrDefaultAsync(x => x.EventID == eventID && x.CommentID == commentID);
            return new CommentObject(o);
        }
        public async Task AddObject(CommentObject o)
       {
           var r = o.DbRecord;
           r.Events = null;
           r.CommentsProfile = null;
           dbSet.Add(r);
           await db.SaveChangesAsync();
       }
        public async Task UpdateObject(CommentObject o)
       {
           dbSet.Update(o.DbRecord);
           await db.SaveChangesAsync();
       }
        public async Task LoadEvents(ProfileObject profileObject)
       {
           if (profileObject is null) return;
           var commentID = profileObject.DbRecord.ID ?? string.Empty;
           var events = await dbSet.Include(x => x.Events).
               Where(x => x.CommentID == commentID).AsNoTracking()
               .ToListAsync();
           foreach (var e in events)
           {
               profileObject.UsedInEvent(new EventObject(e.Events));
           }
       }
        public async Task DeleteObject(CommentObject o)
        {
            var r = o.DbRecord;
            r.CommentsProfile = null;
            r.Events = null;
            dbSet.Remove(r);
            await db.SaveChangesAsync();
        }

        public async Task<List<CommentsProfileObject>> GetCommentsList(string eventID)
        {
            var comments = dbSet.Where(p => p.EventID == eventID); //saame kõik selle eventi kkommid

            var list = comments.Select(s => new {s.CommentID}).ToList(); //saame commenti listi
            var commentDbRecordList = new List<CommentsProfileDbRecord>();
            foreach (var value in list)
            {
                string longID = value.ToString();
                int lastIndexOfIDLongVersion = longID.Length - 1;
                string idRightVersion = longID.Substring(12, lastIndexOfIDLongVersion - 1 - 12); //saame õige commentID
                var oneCommentObject = await fullCommentDbSet.AsNoTracking().SingleOrDefaultAsync(x => x.ID == idRightVersion); //saame õige commentID järgi objekti ; tegelikult on oneCommentObject mitte objekt vaid on tegelikult DBREcord
                commentDbRecordList.Add(oneCommentObject); 
            }

            var count = commentDbRecordList.Count; //listi pikkuse
            var pp = new RepositoryPage(count, PageIndex, PageSize);

            return createList(commentDbRecordList, pp);
        }
    }
}
