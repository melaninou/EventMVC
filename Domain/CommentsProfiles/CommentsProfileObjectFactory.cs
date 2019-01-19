using System;
using System.Collections.Generic;
using System.Text;
using Data;
using Data.Comment;

namespace Domain.Comment
{
    public static class CommentsProfileObjectFactory
    {
        public static CommentsProfileObject Create(string id, string userName, DateTime commentAddTime,
            string userPicture, string commentText, string profileID)
        {
            var o = new CommentsProfileDbRecord
            {
                ID = id,
                UserName = userName,
                CommentAddTime = commentAddTime,
                UserPicture = userPicture,
                CommentText = commentText,
                ProfileID = profileID
            };
            return new CommentsProfileObject(o);
        }
    }
}
