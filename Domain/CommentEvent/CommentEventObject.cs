﻿using Data;
using Data.Comment;
using Domain.Comment;
using Domain.Common;
using Domain.Event;

namespace Domain.CommentEvent
{
    public class CommentEventObject : EmptyObject<CommentEventDbRecord>
   {
       public readonly EventObject EventObject;
       public readonly CommentObject CommentObject;

       public CommentEventObject(CommentEventDbRecord eventDbRecord) : base(eventDbRecord)
       {
           DbRecord.Events = DbRecord.Events ?? new EventDbRecord();
           DbRecord.Comments = DbRecord.Comments ?? new CommentDbRecord();

           EventObject = new EventObject(DbRecord.Events);
           CommentObject = new CommentObject(DbRecord.Comments);
       }
   }
}
