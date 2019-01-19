using Data;
using Data.Comment;
using Domain.CommentsProfiles;
using Domain.Event;

namespace Domain.Comment
{
    public static class CommentObjectFactory
    {
        public static CommentObject Create(EventObject eventObject, CommentsProfileObject commentsProfileObject,
            string eventID, string commentID)
        {
            var o = new CommentDbRecord
            {
                EventID = eventID,
                CommentID =commentID,
                Events = eventObject?.DbRecord ?? new EventDbRecord(),
                CommentsProfile = commentsProfileObject?.DbRecord ?? new CommentsProfileDbRecord()
            };
            o.EventID = o.Events.ID;
            o.CommentID = o.CommentsProfile.ID;
            return new CommentObject(o);
        }

        
    }
}
