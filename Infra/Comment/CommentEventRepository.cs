using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using Data;
using Data.Comment;
using Domain.Comment;
using Domain.Event;
using Microsoft.EntityFrameworkCore;
using Open.Infra;

namespace Infra.Comment
{
  public class CommentEventRepository : ObjectsRepository<CommentObject, CommentDbRecord>, ICommentEventObjectsRepository
  {
      internal readonly DbSet<CommentEventDbRecord> eventDbSet;
      internal readonly DbSet<CommentDbRecord> commentDbSet;
      internal readonly DbSet<CommentProfileDbRecord> profileDbSet;
        private readonly DbContext db;

      public CommentEventRepository(EventProjectDbContext c) : base(c?.Comments, c)
      {
          db = c;
          eventDbSet = c?.CommentEvent;
          profileDbSet = c?.CommentProfile;
          commentDbSet = c?.Comments;
      }
      public async Task AddObject(CommentEventObject o)
      {
          var r = o.DbRecord;
          r.Comments = null;
          r.Events = null;
          eventDbSet.Add(r);
          await db.SaveChangesAsync();
      }
      public async Task UpdateObject(CommentEventObject o)
      {
          eventDbSet.Update(o.DbRecord);
          await db.SaveChangesAsync();
      }

      public async Task DeleteObject(CommentEventObject o)
      {
          var r = o.DbRecord;
          r.Comments = null;
          r.Events = null;
          eventDbSet.Remove(r);
          await db.SaveChangesAsync();
      }
      public async Task<CommentEventObject> GetObject(string eventID, string commentID)
      {
          //if (eventID == null || userID == null) return null;
          var o = await eventDbSet.FirstOrDefaultAsync(x => x.EventID == eventID && x.CommentID == commentID);
          return new CommentEventObject(o);
      }
      public Task<CommentEventObject> GetObject(string id)
      {
          throw new NotImplementedException();
      }
      protected internal override CommentObject createObject(CommentDbRecord r)
      {
          return new CommentObject(r);
      }
      protected internal override PaginatedList<CommentObject> createList(List<CommentDbRecord> l, RepositoryPage p)
      {
          return new CommentObjectsList(l, p);
      }

      public async Task<List<CommentObject>> GetCommentsList(string eventID)
      {
          var commentIdList = GetCommentsIDList(eventID);

          var commentDbRecordList = new List<CommentDbRecord>();

          foreach (var value in commentIdList)
          {
              var oneCommentObject = await commentDbSet.AsNoTracking().SingleOrDefaultAsync(x => x.ID == value); //saame õige commentID järgi objekti ; tegelikult on oneCommentObject mitte objekt vaid on tegelikult DBREcord
              commentDbRecordList.Add(oneCommentObject);
          }

          var count = commentDbRecordList.Count; //listi pikkuse
          var pp = new RepositoryPage(count, PageIndex, PageSize);
          return createList(commentDbRecordList, pp);
      }

      public List<string> GetCommentsIDList(string eventID)
      {
          var comments = eventDbSet.Where(p => p.EventID == eventID);
          var list = comments.Select(s => new { s.CommentID }).ToList();
          var commentList = new List<string>();
          foreach (var value in list)
          {
              string longID = value.ToString();
              int lastIndexOfIDLongVersion = longID.Length - 1;
              string idRightVersion = longID.Substring(14, lastIndexOfIDLongVersion - 1 - 14); //saame õige commentID
              commentList.Add(idRightVersion);
          }
          return commentList;
      }
    }
}
