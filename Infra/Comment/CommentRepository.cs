using Core;
using Data.Comment;
using Domain.Comment;
using Domain.CommentEvent;
using Domain.Profile;
using Microsoft.EntityFrameworkCore;
using Open.Infra;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infra.Comment
{
    public class CommentRepository : ObjectsRepository<CommentObject, CommentDbRecord>, ICommentObjectsRepository
    {
        internal readonly DbSet<CommentDbRecord> dbSet;

        internal readonly DbSet<CommentDbRecord> fullCommentDbSet;
        private readonly DbContext db;

        public CommentRepository(EventProjectDbContext c) : base(c?.Comments, c)
        {
            db = c;
            dbSet = c?.Comments;
            //fullCommentDbSet = c?.CommentsProfile;
        }
        protected internal override CommentObject createObject(CommentDbRecord r)
        {
            return new CommentObject(r);
        }
        protected internal override PaginatedList<CommentObject> createList(List<CommentDbRecord> l, RepositoryPage p)
        {
            return new CommentObjectsList(l, p);
        }
        public Task<CommentEventObject> GetObject(string id)
        {
            throw new NotImplementedException();
        }

        public void AddExtra(CommentObject co, ProfileObject po)
        {

        }
        
      
     
     
        //public async Task<List<CommentObject>> GetCommentsList(string eventID)
        //{
        //    var comments = eventDbSet.Where(p => p.EventID == eventID); //saame kõik selle eventi kkommid

        //    var list = comments.Select(s => new {s.CommentID}).ToList(); //saame commenti listi
        //    var commentDbRecordList = new List<CommentDbRecord>();
        //    foreach (var value in list)
        //    {
        //        string longID = value.ToString();
        //        int lastIndexOfIDLongVersion = longID.Length - 1;
        //        string idRightVersion = longID.Substring(12, lastIndexOfIDLongVersion - 1 - 12); //saame õige commentID
        //        var oneCommentObject = await fullCommentDbSet.AsNoTracking().SingleOrDefaultAsync(x => x.ID == idRightVersion); //saame õige commentID järgi objekti ; tegelikult on oneCommentObject mitte objekt vaid on tegelikult DBREcord
        //        commentDbRecordList.Add(oneCommentObject); 
        //    }

        //    var count = commentDbRecordList.Count; //listi pikkuse
        //    var pp = new RepositoryPage(count, PageIndex, PageSize);

        //    return createList(commentDbRecordList, pp);
        //}
    }
}
