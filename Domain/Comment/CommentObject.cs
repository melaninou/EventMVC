using System;
using System.Collections.Generic;
using System.Text;
using Data;
using Data.Comment;
using Domain.Common;
using Domain.Event;

namespace Domain.Comment
{
   public class CommentObject : EmptyObject<CommentDbRecord>
   {
       public readonly EventObject EventObject;
       public readonly CommentsProfileObject CommentsProfileObject;

       public CommentObject(CommentDbRecord dbRecord) : base(dbRecord)
       {
           DbRecord.Events = DbRecord.Events ?? new EventDbRecord();
           DbRecord.CommentsProfile = DbRecord.CommentsProfile ?? new CommentsProfileDbRecord();

           EventObject = new EventObject(DbRecord.Events);
           CommentsProfileObject = new CommentsProfileObject(DbRecord.CommentsProfile);
       }
   }
}
