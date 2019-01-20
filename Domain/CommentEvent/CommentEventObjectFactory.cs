using System;
using System.Collections.Generic;
using System.Text;
using Data;
using Data.Comment;
using Domain.Event;

namespace Domain.Comment
{
    public static class CommentEventObjectFactory
    {
        public static CommentEventObject Create(EventObject eventObject, CommentObject commentObject,
            string eventID, string commentID)
        {
            var o = new CommentEventDbRecord
            {
                EventID = eventID,
                CommentID =commentID,
                Events = eventObject?.DbRecord ?? new EventDbRecord(),
                Comments = commentObject?.DbRecord ?? new CommentDbRecord()
            };
            o.EventID = o.Events.ID;
            o.CommentID = o.Comments.ID;
            return new CommentEventObject(o);
        }

        
    }
}
