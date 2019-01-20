using System;
using System.Collections.Generic;
using System.Text;
using Data;
using Data.Comment;
using Domain.Attending;
using Domain.Comment;
using Domain.Profile;

namespace Domain.CommentProfile
{
   public static class CommentProfileObjectFactory
    {
        public static CommentProfileObject Create(CommentObject commentObject, ProfileObject profileObject,
            string commentID, string userID)
        {
            var o = new CommentProfileDbRecord
            {
                CommentID= commentID,
                ProfileID = userID,
                Comments = commentObject?.DbRecord ?? new CommentDbRecord(),
                Profiles = profileObject?.DbRecord ?? new ProfileDbRecord()
            };
            o.CommentID = o.Comments.ID;
            o.ProfileID = o.Profiles.ID;
            return new CommentProfileObject(o);
        }
    }
}
